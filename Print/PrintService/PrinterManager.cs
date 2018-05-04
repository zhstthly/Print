using BLL;
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
using System.Reflection;

namespace PrintServer
{
    public class PrinterManager
    {
        static int printIndex = 0;
        public static PrinterPaper CurrentPrintPage
        {
            get { return PrinterPaper.CurrentPrintPage; }
        }

        public static PrintEditResultModel GetModel(Guid templateModelID)
        {
            List<TemplateModel> templateList = DataManager.TemplateM;
            PrintEditResultModel pmhf = new PrintEditResultModel();
            pmhf.Extends = new Dictionary<string, object>();
            pmhf.Fields = new List<FieldModel>();
            TemplateModel tm = templateList.Find(t => t.ModelID == templateModelID);
            if (tm == null)
                throw new Exception("没有配置模板！");
            pmhf.TemplateModel = tm;
            List<FieldModel> fieldList = DataManager.FieldM;
            foreach (FieldModel fm in fieldList)
            {
                if (fm.ModelID == tm.ModelID)
                    pmhf.Fields.Add(fm);
            }
            return pmhf;
        }

        //打印发货单或快递单
        public static void PrintOrder(Guid templateModelID, OrderPrintDataDTO orderPrintDataDto, string printerName,
            DataEntity.PrintType printType, YesOrNo isGlass, PrintAbout printAbout)
        {
            if (printAbout == PrintAbout.Order && (printType == DataEntity.PrintType.Manual || printType == DataEntity.PrintType.Again))
            {
                WMSService.CurrentWMSService.RecordPrinted(orderPrintDataDto.DownGoodsBillNo);
            }
            CurrentPrintPage.About = printAbout;
            //打印数据初始化
            PrintEditResultModel perm = GetModel(templateModelID);
            CurrentPrintPage.PrintEntity = EntityConvert<OrderDetailPrintDataDTO>.Objs2Fields(perm, Machining.MachiningOrder(orderPrintDataDto));
            perm.Extends.Add("PrintType", printType);
            //纸张设置默认
            if (CurrentPrintPage.PrintEntity.PageModel != null)
            {
                CurrentPrintPage.DefaultPageSettings.PaperSize = new PaperSize(
                    CurrentPrintPage.PrintEntity.PageModel.PageName,
                    CommonFunction.Millimeter2Pix(CurrentPrintPage.PrintEntity.PageModel.Width),
                    CommonFunction.Millimeter2Pix(CurrentPrintPage.PrintEntity.PageModel.Height));
            }

            // 打印机名称
            CurrentPrintPage.PrinterSettings.PrinterName = printerName;
            CurrentPrintPage.DocumentName = printIndex++.ToString();
            if (CurrentPrintPage.PrinterSettings.IsValid)
            {
                CurrentPrintPage.Print();
            }
        }

        /// <summary>启动打印
        /// </summary>
        public static void PrintEngine()
        {
            var expSelectedList = ConfigManager.ConfigInfo.ExpList.Where(e => e.Selected).ToList();
            if (expSelectedList.Count == 0)
                return;
            else if (expSelectedList.Count != 1)
                throw new ArgumentException("必须勾选1个且只有1个快递公司使用自动打印服务，请重新设置！");
            var expSelected = expSelectedList[0];
            //取得与打印机绑订的快递公司模版
            if (ConfigManager.ConfigInfo.PrintOrderModel == null
                || ConfigManager.ConfigInfo.PrintOrderModel == new Guid())
                throw new Exception("未找到模版");
            if (string.IsNullOrEmpty(expSelected.ExpressPrinter))
                throw new Exception("未绑定打印机");


            //首先检查有没有上次没有打印的订单
            if (WMSService.WMSGroupOrder.Count == 0)
            {
                //重新获取订单
                Guid _warehouseId = new Guid(ConfigManager.ConfigInfo.WarehouseId);
                Guid _hosttingFilialeId = new Guid(ConfigManager.ConfigInfo.InvoiceFilialeId);
                var salePlatformIds = ConfigManager.ConfigInfo.PrintPlatformSetModelList.Where(ent => ent.IsProcess).Select(ent => ent.SalePlatformId).ToList();
                var expressIds = expSelectedList.Select(exp => exp.ExpressCompanyId).ToList();
                var result = WMSService.CurrentWMSService.AutoPrintOrderBills(_warehouseId, _hosttingFilialeId,
                salePlatformIds, expressIds, false, 10, ConfigManager.ConfigInfo.OrderType);
                //缓存打印数据
                if (result.IsSuccess)
                {
                    WMSService.WMSGroupOrder.Clear();
                    List<OrderPrintDataDTO> cacheDatas = new List<OrderPrintDataDTO>();
                    //将待打印的订单记录缓存
                    foreach (var orderPrintDataDto in result.Data)
                    {
                        cacheDatas.Add(orderPrintDataDto);
                    }
                    WMSService.WMSGroupOrder = cacheDatas;
                }
            }
            for (int i = 0; i < WMSService.WMSGroupOrder.Count;)
            {
                OrderPrintDataDTO printOrder = WMSService.WMSGroupOrder[0];
                try
                {
                    //打印发货单
                    PrintOrder(ConfigManager.ConfigInfo.PrintOrderModel, printOrder,
                        expSelectedList[0].OrderPrinter, DataEntity.PrintType.Auto, YesOrNo.No, PrintAbout.Order);
                    //打印快递单
                    if (expSelectedList[0].AutoPrint)
                        PrintOrder(expSelectedList[0].ExpressPrintModel, printOrder,
                            expSelectedList[0].ExpressPrinter, DataEntity.PrintType.Auto, YesOrNo.No, PrintAbout.Express);
                    WMSService.WMSGroupOrder.Remove(printOrder);
                    WMSService.UpdateCacheData();
                }
                catch (Exception ex)
                {
                    WMSService.NoPrintedResetReaderId(WMSService.WMSGroupOrder.Select(t => t.DownGoodsBillNo).ToList());
                    throw ex;
                }
            }
        }
    }
}
