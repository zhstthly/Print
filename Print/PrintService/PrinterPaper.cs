using DataEntity;
using Fath;
using Infrastructure;
using PrintEntity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintServer
{
    public class PrinterPaper : PrintDocument
    {
        static PrinterPaper currentPrintPage;
        public static PrinterPaper CurrentPrintPage
        {
            get
            {
                if (currentPrintPage == null)
                {
                    currentPrintPage = new PrinterPaper();
                    currentPrintPage.PrintEntity = new PrintEditResultModel();
                    currentPrintPage.DefaultPageSettings.Margins.Left = 0;
                    currentPrintPage.DefaultPageSettings.Margins.Top = 0;
                    currentPrintPage.DefaultPageSettings.Margins.Right = 0;
                    currentPrintPage.DefaultPageSettings.Margins.Bottom = 0;
                    currentPrintPage.PrintController = new StandardPrintController();
                    currentPrintPage.PrintPage += CurrentPrinter_PrintPage;
                }
                return currentPrintPage;
            }

        }

        public static int PrintDataBlock(FieldModel fm, List<List<DataBlockMapping>> dbmappingListList, PrintPageEventArgs e)
        {
            //判断数据块模板是否存在
            DataBlockTemplateModel dbtm = DataManager.DataBlockTemplateM.Find(t => t.ModelName == fm.FieldName);
            if (dbtm == null)
                throw new Exception("数据块模板丢失");
            //获取行高度
            Font printFont = new Font(new FontFamily(dbtm.FontFamilyName), dbtm.FontSize);
            float fontHeight = e.Graphics.MeasureString("高", printFont).Height;
            //获取该模板对应的数据块模板
            List<DataBlockModel> dbmList = DataManager.DataBlockM.Where(m => m.TemplateModelID == dbtm.ModelID).
                OrderBy(m => m.Index).ToList();
            //每一行的打印坐标X（左缩进+数据块位置（一般为0））
            int locationX = dbtm.PaddingLeft + fm.LocationX;
            //打印的Y坐标（数据块坐标+上缩进+行高+行间距）
            int locationY = dbtm.PaddingTop + (int)fontHeight + dbtm.Distance;
            //分割线的宽度（减掉左右缩进）
            int lineWidth = fm.TextAreaWidth - dbtm.PaddingLeft - dbtm.PaddingRight;
            //打印表头列名
            if (!CurrentPrintPage.DataBlockContinue)
            {
                foreach (var dbm in dbmList)
                {
                    e.Graphics.DrawString(dbm.ColumnName, printFont,
                        Brushes.Black, new PointF(locationX, fm.LocationY + dbtm.PaddingTop));
                    locationX += dbm.ColumnWidth;
                }
                locationY = fm.LocationY + dbtm.PaddingTop + (int)fontHeight + dbtm.Distance;
                //画分割线（上）
                PrintLine(new FieldModel()
                {
                    LocationX = dbtm.PaddingLeft + fm.LocationX,
                    LocationY = locationY,
                    TextAreaWidth = lineWidth,
                    TextAreaHeight = dbtm.LineWidth
                }, 0, DashStyle.Solid, e);
                locationY += dbtm.LineWidth;
            }

            //打印数据行，要处理分页问题
            locationY += dbtm.Distance * 2;
            for (int i = 0; i < dbmappingListList.Count;)
            {
                var dbmappingList = dbmappingListList[i];
                //判断纸张是否支持下一行打印，为了简便，当剩余高度不足两个行高+两个行间距+分割线宽度+5（弹性距离），则换页
                if ((fontHeight + dbtm.Distance) * 2 + dbtm.LineWidth + 5 >
                    CommonFunction.Millimeter2Pix(CurrentPrintPage.PrintEntity.PageModel.Height) - locationY)
                {
                    //换页处理
                    CurrentPrintPage.DataBlockContinue = e.HasMorePages = true;
                    return 0;
                }
                //打印下一行
                bool doubleHeight = false;
                locationX = dbtm.PaddingLeft + fm.LocationX;
                foreach (var dbm in dbmList)
                {
                    DataBlockMapping dbmapping = dbmappingList.Find(m => m.PrintName == dbm.ColumnName);
                    if (dbmapping == null)
                        continue;
                    if (e.Graphics.MeasureString(dbmapping.DataValue, printFont).Width > dbm.ColumnWidth)
                    {
                        e.Graphics.DrawString(dbmapping.DataValue, printFont,
                        Brushes.Black, new RectangleF(locationX, locationY, dbm.ColumnWidth, fontHeight * 2));
                        doubleHeight = true;
                    }
                    else
                    {
                        e.Graphics.DrawString(dbmapping.DataValue, printFont,
                        Brushes.Black, new PointF(locationX, locationY));
                    }
                    locationX += dbm.ColumnWidth;
                }
                //打印完之后删数据
                dbmappingListList.Remove(dbmappingList);

                locationY += (doubleHeight ? (int)(fontHeight * 2) : (int)fontHeight) + dbtm.Distance;
                if (dbmappingListList.IndexOf(dbmappingList) < dbmappingListList.Count - 1)
                {
                    //画分割线（数据）
                    PrintLine(new FieldModel()
                    {
                        LocationX = dbtm.PaddingLeft + fm.LocationX,
                        LocationY = locationY,
                        TextAreaWidth = lineWidth,
                        TextAreaHeight = 1
                    }, 0, DashStyle.Dot, e);
                    locationY += dbtm.Distance + 1;
                }
            }

            //画分割线（下）
            PrintLine(new FieldModel()
            {
                LocationX = dbtm.PaddingLeft + fm.LocationX,
                LocationY = locationY,
                TextAreaWidth = lineWidth,
                TextAreaHeight = dbtm.LineWidth
            }, 0, DashStyle.Solid, e);
            locationY += dbtm.LineWidth;
            int adjustHeight = locationY - fm.TextAreaHeight - fm.LocationY - dbtm.PaddingTop;
            CurrentPrintPage.DataBlockContinue = e.HasMorePages = false;
            CurrentPrintPage.PrintEntity.Fields.Remove(fm);
            return adjustHeight;
        }

        private static void PrintBarCode(FieldModel fm, int adjustHeight, PrintPageEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(fm.BindingText))
                    return;
                int locationY = fm.LocationY + adjustHeight;
                var pickNoBarcode = new BarcodeX { Data = fm.BindingText, ShowText = false, Symbology = bcType.Code128 };
                e.Graphics.DrawImage(pickNoBarcode.Image(fm.TextAreaWidth, fm.TextAreaHeight),
                    fm.LocationX, locationY);
            }
            finally
            {
                CurrentPrintPage.PrintEntity.Fields.Remove(fm);
            }
        }

        private static void PrintLine(FieldModel fm, int adjustHeight, DashStyle ds, PrintPageEventArgs e)
        {
            int locationY = fm.LocationY + adjustHeight;
            float penWidth = Math.Min(fm.TextAreaWidth, fm.TextAreaHeight);
            var pen = new Pen(Brushes.Black, penWidth) { DashStyle = ds };
            if (fm.TextAreaWidth > fm.TextAreaHeight)
                e.Graphics.DrawLine(pen, fm.LocationX, locationY, fm.LocationX + fm.TextAreaWidth, locationY);
            else
                e.Graphics.DrawLine(pen, fm.LocationX, locationY, fm.LocationX, locationY + fm.TextAreaHeight);
            CurrentPrintPage.PrintEntity.Fields.Remove(fm);
        }

        public static void PrintImage(FieldModel fm, int adjustHeight, PrintPageEventArgs e)
        {
            //打印图片
            try
            {
                string fileName = fm.FieldName + "_" + fm.BindingText + ".jpg";
                Image img = DataManager.DownLoadImage(fileName);
                if (img == null)
                    return;
                e.Graphics.DrawImage(img, new RectangleF(fm.LocationX, fm.LocationY, fm.TextAreaWidth, fm.TextAreaHeight));
            }
            finally
            {
                CurrentPrintPage.PrintEntity.Fields.Remove(fm);
            }
        }

        public static void PrintString(FieldModel fm, int adjustHeight, PrintPageEventArgs e)
        {
            int locationY = fm.LocationY + adjustHeight;
            FontStyle fs = (fm.Bold ? FontStyle.Bold : FontStyle.Regular) |
                (fm.Italic ? FontStyle.Italic : FontStyle.Regular);
            if (fm.TextAreaWidth == 0 || fm.TextAreaHeight == 0)
            {
                e.Graphics.DrawString(fm.BindingText, new Font(new FontFamily(fm.FontFamilyName), (float)fm.FontSize, fs),
                        Brushes.Black, new PointF(fm.LocationX, locationY));
            }
            else
            {
                e.Graphics.DrawString(fm.BindingText, new Font(new FontFamily(fm.FontFamilyName), (float)fm.FontSize, fs),
                        Brushes.Black, new RectangleF(fm.LocationX, locationY, fm.TextAreaWidth, fm.TextAreaHeight));
            }
            CurrentPrintPage.PrintEntity.Fields.Remove(fm);
        }

        private static void CurrentPrinter_PrintPage(object sender, PrintPageEventArgs e)
        {
            //如果是打印快递单，先加载销售平台的底图
            if (CurrentPrintPage.About == PrintAbout.Express && CurrentPrintPage.PrintEntity.Extends["SaleFilialeId"] != null)
            {
                PrintImage(new FieldModel()
                {
                    FieldName = "express",
                    BindingText = CurrentPrintPage.PrintEntity.Extends["SaleFilialeId"].ToString(),
                    LocationX = 0,
                    LocationY = 0,
                    TextAreaWidth = CurrentPrintPage.DefaultPageSettings.PaperSize.Width,
                    TextAreaHeight = CurrentPrintPage.DefaultPageSettings.PaperSize.Height
                }, 0, e);
            }
            //高度调整，如果数据块高度和设计的高度有差别，则adjustHeight保存差别值
            int adjustHeight = 0;
            if (CurrentPrintPage.BlockChangeToNewPage)
            {
                //如果换页,偏移量是第一个打印数据的高度
                FieldModel offsetFm = CurrentPrintPage.PrintEntity.Fields.OrderBy(f => f.LocationY).OrderBy(f => f.LocationX).FirstOrDefault();
                if (offsetFm != null)
                    adjustHeight = -offsetFm.LocationY + 20;
            }
            //先打印所有数据块之前的字段
            FieldModel dbfm = CurrentPrintPage.PrintEntity.Fields.Find(f => f.FieldType == FieldType.DataBlock);
            if (dbfm != null)
            {
                List<FieldModel> beforedbfmData = CurrentPrintPage.PrintEntity.Fields.Where(f => f.LocationY < dbfm.LocationY).ToList();
                foreach (FieldModel fm in beforedbfmData)
                {
                    switch (fm.FieldType)
                    {
                        case FieldType.String:
                            PrintString(fm, adjustHeight, e);
                            break;
                        case FieldType.Image:
                            PrintImage(fm, adjustHeight, e);
                            break;
                        case FieldType.Line:
                            PrintLine(fm, adjustHeight, DashStyle.Solid, e);
                            break;
                        case FieldType.BarCode:
                            PrintBarCode(fm, adjustHeight, e);
                            break;
                    }
                }
                //然后打印数据块
                adjustHeight = PrintDataBlock(dbfm, CurrentPrintPage.PrintEntity.DataEntity, e);
                //打印数据块需要换页
                if (CurrentPrintPage.DataBlockContinue)
                    return;
            }
            //首先判断剩下的纸张高度够不够打印 如果adjustPoint.Y > 0,且 不分页块+留白块 < 剩下的打印空间，则换页
            //（暂时将数据块后所有内容表示为不分页块，以后拓展程序可以改进）
            if (adjustHeight > 0)
            {
                CurrentPrintPage.BlockChangeToNewPage = e.HasMorePages = true;
                return;
            }
            //先对字段进行排序，剩下的字段从上往下顺序打
            CurrentPrintPage.PrintEntity.Fields = CurrentPrintPage.PrintEntity.Fields.
                OrderBy(f => f.LocationY).OrderBy(f => f.LocationX).ToList();
            for (int i = 0; i < CurrentPrintPage.PrintEntity.Fields.Count;)
            {
                FieldModel fm = CurrentPrintPage.PrintEntity.Fields[0];
                switch (fm.FieldType)
                {
                    case FieldType.String:
                        PrintString(fm, adjustHeight, e);
                        break;
                    case FieldType.Image:
                        PrintImage(fm, adjustHeight, e);
                        break;
                    case FieldType.Line:
                        PrintLine(fm, adjustHeight, DashStyle.Solid, e);
                        break;
                    case FieldType.BarCode:
                        PrintBarCode(fm, adjustHeight, e);
                        break;
                }
            }
            //最后是留白部分（发货单专享打印图片和电子发票，先照搬之前的代码）
            if (CurrentPrintPage.About == PrintAbout.Order && CurrentPrintPage.PrintEntity.PageModel.BlankHeight > 0)
            {
                if (CurrentPrintPage.PrintEntity.Extends["OrderNos"] != null
                    && CurrentPrintPage.PrintEntity.Extends["SalePlatformId"] != null
                    && CurrentPrintPage.PrintEntity.Extends["DimensionalCodeDto"] != null)
                {
                    var orderNos = CurrentPrintPage.PrintEntity.Extends["OrderNos"].ToString();
                    var salePlatformId = CurrentPrintPage.PrintEntity.Extends["SalePlatformId"].ToString();
                    var printType = (DataEntity.PrintType)CurrentPrintPage.PrintEntity.Extends["PrintType"];
                    var dimensionalCodeDto = CurrentPrintPage.PrintEntity.Extends["DimensionalCodeDto"] as DimensionalCodeDTO;
                    int barCodeLeft;
                    int currentY = CurrentPrintPage.PrintEntity.PageModel.Height - (int)CommonFunction.Pix2Millimeter(CurrentPrintPage.PrintEntity.PageModel.BlankHeight);
                    QRCodeService.PrintEInvoiceAndQRCode(e, orderNos, salePlatformId,
                        dimensionalCodeDto, ref currentY, out barCodeLeft);
                    #region [打印总单号条形码]
                    if (printType == DataEntity.PrintType.Auto && CurrentPrintPage.PrintEntity.Extends["TotalBillNo"] != null)
                    {
                        var totalBillNo = CurrentPrintPage.PrintEntity.Extends["TotalBillNo"].ToString();
                        var pickNoBarcode = new BarcodeX { Data = totalBillNo, ShowText = false, Symbology = bcType.Code128 };
                        e.Graphics.DrawImage(pickNoBarcode.Image(160, 40), CommonFunction.Millimeter2Pix(barCodeLeft), CommonFunction.Millimeter2Pix(currentY));
                    }
                    #endregion
                }
            }
            CurrentPrintPage.BlockChangeToNewPage = e.HasMorePages = false;
            if (CurrentPrintPage.PrintEntity.Fields.Count > 0)
                throw new Exception("打印数据不完全");
        }

        private PrinterPaper()
        {

        }
        public PrintEditResultModel PrintEntity { get; set; }
        public PrintAbout About { get; set; }
        public bool DataBlockContinue { get; set; }
        public bool BlockChangeToNewPage { get; set; }
    }
}
