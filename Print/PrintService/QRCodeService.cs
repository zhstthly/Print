using BLL;
using DataEntity;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;

namespace PrintServer
{
    public class QRCodeService
    {
        private static readonly Font _font9 = new Font(FontFamily.GenericSerif, 9.0f);
        private static readonly Font _font9B = new Font(FontFamily.GenericSerif, 9.0f, FontStyle.Bold);
        //行间隔：1
        const int ROW_SPACE = 1;
        /// <summary>  
        /// 生成二维码图片  
        /// </summary>  
        /// <param name="codeNumber">要生成二维码的字符串</param>       
        /// <param name="size">大小尺寸</param>  
        /// <returns>二维码图片</returns>  
        static Bitmap StringToQRCode(string codeNumber, int size)
        {
            //创建二维码生成类  
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //设置编码模式  
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //设置编码测量度  
            qrCodeEncoder.QRCodeScale = size;
            //设置编码版本  
            qrCodeEncoder.QRCodeVersion = 0;
            //设置编码错误纠正  
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //生成二维码图片  
            Bitmap image = qrCodeEncoder.Encode(codeNumber);
            return image;
        }

        static Bitmap GetThumbnail(Bitmap b, int destWidth, int destHeight)
        {
            Image imgSource = b;
            // 按比例缩放           
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            float proportion = 1;
            if ((float)sWidth / sHeight >= (float)destWidth / destHeight)
            {
                //根据destWidth来缩放,缩放比例为
                proportion = (float)destWidth / sWidth;
            }
            else
            {
                //根据destHeight来缩放
                proportion = (float)destHeight / sHeight;
            }
            int dWith = (int)(sWidth * proportion);
            int dHeight = (int)(sHeight * proportion);
            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量         
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new Rectangle(0, (destHeight - dHeight) / 2, (int)(sWidth * proportion), (int)(sHeight * proportion)),
                new Rectangle(0, 0, imgSource.Width, imgSource.Height), GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量     
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            imgSource.Dispose();
            return outBmp;
        }

        public static void PrintEInvoiceAndQRCode(PrintPageEventArgs e, string orderNo, string platformId, 
            DimensionalCodeDTO dimensionalCodeDTO, ref int currentY, out int barCodeLeft)
        {
            //二维码打印配置变量
            string[] print_Param = new string[] { "Interval", "EInvoiceLeft", "BarCodeLeft", "DownLoadFileUri" };
            //Json获取配置信息
            var extends = WMSService.CurrentWMSService.GetExtends(dimensionalCodeDTO.Extends, print_Param);
            var interval = extends.ContainsKey("Interval") ? Convert.ToInt32(extends["Interval"]) : 8;
            var eInvoiceLeft = extends.ContainsKey("EInvoiceLeft") ? Convert.ToInt32(extends["EInvoiceLeft"]) : 2;
            var downloadApiUrl = DimensionalCodeAdvertisementDao.GetDownloadApiUrl(ConfigManager.ApiUrl);
            var eInvoiceFormatString = DimensionalCodeAdvertisementDao.GetEInvoiceFormatString(ConfigManager.ApiUrl);
            barCodeLeft = extends.ContainsKey("BarCodeLeft") ? Convert.ToInt32(extends["BarCodeLeft"]) : 155;

            //图片和纸张缩放比例
            float propertion = 0.12f;
            //图片打印区域的最大宽度和高度
            var printWith = 1250 * propertion;
            var printHeight = 250 * propertion;
            var printEInvoice = false;
            #region [打印电子发票]
            if (dimensionalCodeDTO.PrintEInvoice &&
                !string.IsNullOrEmpty(eInvoiceFormatString))
            {
                printEInvoice = true;
                Bitmap eInvoiceBmp = GetThumbnail(StringToQRCode(string.Format(eInvoiceFormatString, orderNo, platformId), 10),
                (int)(printHeight / 0.12f), (int)(printHeight / 0.12f));
                e.Graphics.DrawImage(eInvoiceBmp, new RectangleF(CommonFunction.Millimeter2Pix(eInvoiceLeft), CommonFunction.Millimeter2Pix(currentY + 4 + ROW_SPACE),
                    CommonFunction.Millimeter2Pix((decimal)printHeight), CommonFunction.Millimeter2Pix((decimal)printHeight)));
                e.Graphics.DrawString("         如需发票\r\n请扫描二维码领取", _font9, Brushes.Black,
                    new RectangleF(CommonFunction.Millimeter2Pix(eInvoiceLeft), CommonFunction.Millimeter2Pix(currentY + 5 + ROW_SPACE + (decimal)printHeight),
                    CommonFunction.Millimeter2Pix((decimal)printHeight + 5), CommonFunction.Millimeter2Pix(currentY + 18)));
                printWith -= printHeight;
                printWith -= interval;
            }
            #endregion
            #region [打印二维码]
            //打印二维码
            if (dimensionalCodeDTO.IsEnable && !string.IsNullOrEmpty(dimensionalCodeDTO.ImageFileName))
            {

                e.Graphics.DrawString(dimensionalCodeDTO.MessageTop, _font9B, Brushes.Black,
                    new RectangleF(CommonFunction.Millimeter2Pix(eInvoiceLeft + (printEInvoice ? ((decimal)printHeight + interval) : 0)), CommonFunction.Millimeter2Pix(currentY + 1),
                    CommonFunction.Millimeter2Pix((decimal)printWith), CommonFunction.Millimeter2Pix(currentY + 5)));
                currentY += (3 + ROW_SPACE);
                var wechatImage = GetThumbnail(DimensionalCodeAdvertisementDao.GetQRCodeImage(dimensionalCodeDTO.ImageFileName.ToString(), downloadApiUrl) as Bitmap,
                    (int)(printWith / 0.12f), (int)(printHeight / 0.12f));
                e.Graphics.DrawImage(wechatImage, new RectangleF(CommonFunction.Millimeter2Pix(eInvoiceLeft + (printEInvoice ? ((decimal)printHeight + interval) : 0)),
                    CommonFunction.Millimeter2Pix(currentY + 1), CommonFunction.Millimeter2Pix((decimal)printWith), CommonFunction.Millimeter2Pix((decimal)printHeight)));
                currentY += 20;
                e.Graphics.DrawString(dimensionalCodeDTO.MessageButton, _font9, Brushes.Black,
                    new RectangleF(CommonFunction.Millimeter2Pix(eInvoiceLeft + (printEInvoice ? ((decimal)printHeight + interval) : 0)), CommonFunction.Millimeter2Pix(currentY + 12),
                    CommonFunction.Millimeter2Pix((decimal)printWith - (eInvoiceLeft + (decimal)printHeight + interval)), CommonFunction.Millimeter2Pix(currentY + 18)));
            }
            #endregion
        }
    }
}
