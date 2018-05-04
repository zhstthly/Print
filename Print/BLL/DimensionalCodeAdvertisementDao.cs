using Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DimensionalCodeAdvertisementDao
    {
        static Dictionary<string, byte[]> imageDictionary = new Dictionary<string, byte[]>();
        static Dictionary<string, string> configDictionary = new Dictionary<string, string>();

        public static string GetDownloadApiUrl(string actionUri)
        {
            if (!configDictionary.ContainsKey("DownLoadFileUri"))
            {
                WebClient wc = new WebClient();
                Encoding enc = Encoding.GetEncoding("UTF-8");
                string pageData = wc.DownloadString(new Uri(new Uri(actionUri),
                    ConfigManager.DownLoadFileUriApiAction));
                string value = pageData.Split(',')[0];
                value = value.Substring(9, value.Length - 10);
                if (pageData.Length == 0)
                    throw new Exception("找不到配置信息:DownLoadFileUri");
                configDictionary.Add("DownLoadFileUri", value);
            }
            return configDictionary["DownLoadFileUri"];
        }

        public static string GetEInvoiceFormatString(string actionUri)
        {
            if (!configDictionary.ContainsKey("EInvoiceUrlFormatString"))
            {
                WebClient wc = new WebClient();
                Encoding enc = Encoding.GetEncoding("UTF-8");
                string pageData = wc.DownloadString(new Uri(new Uri(actionUri),
                    ConfigManager.EInvoiceUrlFormatStringApiAction));
                string value = pageData.Split(',')[0];
                value = value.Substring(9, value.Length - 10);
                if (pageData.Length == 0)
                    throw new Exception("找不到配置信息:EInvoiceUrlFormatString");
                configDictionary.Add("EInvoiceUrlFormatString", value);
            }
            return configDictionary["EInvoiceUrlFormatString"];
        }

        public static Image GetQRCodeImage(string imageName, string downloadImagePath)
        {
            if (!imageDictionary.ContainsKey(imageName))
            {
                WebClient wc = new WebClient();
                Encoding enc = Encoding.GetEncoding("UTF-8");
                byte[] pageData = wc.DownloadData(new Uri(new Uri(downloadImagePath),
                    string.Format(ConfigManager.ImageApiAction, imageName)));
                if (pageData.Length == 0)
                    throw new Exception("二维码图片已丢失");
                imageDictionary.Add(imageName, pageData);
            }
            byte[] imageData = imageDictionary[imageName];
            Image image = null;
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                ms.Write(imageData, 0, imageData.Length);
                image = Image.FromStream(ms, true);
            }
            return image;
        }
    }
}
