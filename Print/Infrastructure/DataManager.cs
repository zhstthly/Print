using DataEntity;
using Infrastructure;
using Newtonsoft.Json;
using PrintEntity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DataManager
    {
        static List<PrintFieldsBindingModel> printFieldsBMList;
        static List<TemplateModel> printMList;
        static List<FieldModel> fieldMList;
        static List<DataBlockTemplateModel> dataBlockTemplateMList;
        static List<DataBlockModel> dataBlockMList;
        static List<PageModel> pageMList;
        static List<PictureGroupModel> pictureGroupMList;
        static Dictionary<string, byte[]> imageDictionary = new Dictionary<string, byte[]>();
        static List<PrintSenderDTO> printSenderDTOList;

        public static List<PrintFieldsBindingModel> PrintFieldsBM
        {
            get
            {
                if (printFieldsBMList == null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] getBytes = wc.DownloadData(ConfigManager.ServerPrintFieldsBindingPath);
                        printFieldsBMList = JsonConvert.DeserializeObject<List<PrintFieldsBindingModel>>(Encoding.UTF8.GetString(getBytes));
                    }
                }
                return printFieldsBMList;
            }
        }

        public static List<DataBlockModel> DataBlockM
        {
            get
            {
                if (dataBlockMList == null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] getBytes = wc.DownloadData(ConfigManager.ServerDataBlockModelPath);
                        dataBlockMList = JsonConvert.DeserializeObject<List<DataBlockModel>>(Encoding.UTF8.GetString(getBytes));
                    }
                }
                return dataBlockMList;
            }
        }

        public static List<DataBlockTemplateModel> DataBlockTemplateM
        {
            get
            {
                if (dataBlockTemplateMList == null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] getBytes = wc.DownloadData(ConfigManager.ServerDataBlockTemplateModelPath);
                        dataBlockTemplateMList = JsonConvert.DeserializeObject<List<DataBlockTemplateModel>>(Encoding.UTF8.GetString(getBytes));
                    }
                }
                return dataBlockTemplateMList;
            }
        }

        public static List<PageModel> PageM
        {
            get
            {
                if (pageMList == null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] getBytes = wc.DownloadData(ConfigManager.ServerPageModelPath);
                        pageMList = JsonConvert.DeserializeObject<List<PageModel>>(Encoding.UTF8.GetString(getBytes));
                    }
                }
                return pageMList;
            }
        }

        public static List<TemplateModel> TemplateM
        {
            get
            {
                if(printMList == null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] getBytes = wc.DownloadData(ConfigManager.ServerTemplateModelPath);
                        printMList = JsonConvert.DeserializeObject<List<TemplateModel>>(Encoding.UTF8.GetString(getBytes));
                    }
                }
                return printMList;
            }
        }

        public static List<FieldModel> FieldM
        {
            get
            {
                if (fieldMList == null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] getBytes = wc.DownloadData(ConfigManager.ServerFieldModelPath);
                        fieldMList = JsonConvert.DeserializeObject<List<FieldModel>>(Encoding.UTF8.GetString(getBytes));
                    }
                }
                return fieldMList;
            }
        }

        public static List<PictureGroupModel> PictureGroupM
        {
            get
            {
                if (pictureGroupMList == null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] getBytes = wc.DownloadData(ConfigManager.ServerPictureGroupPath);
                        pictureGroupMList = JsonConvert.DeserializeObject<List<PictureGroupModel>>(Encoding.UTF8.GetString(getBytes));
                        //给做数据源时一个默认空选项
                        pictureGroupMList.Insert(0, new PrintEntity.PictureGroupModel { ID = new Guid(), GroupName = "" });
                    }
                }
                return pictureGroupMList;
            }
        }

        public static List<PrintSenderDTO> PrintSenderDTOList
        {
            get
            {
                if (printSenderDTOList == null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] getBytes = wc.DownloadData(ConfigManager.ServerPrintSenderDTOPath);
                        printSenderDTOList = JsonConvert.DeserializeObject<List<PrintSenderDTO>>(Encoding.UTF8.GetString(getBytes));
                    }
                }
                return printSenderDTOList;
            }
        }

        public static Image DownLoadImage(string imageName)
        {
            if (!imageDictionary.Keys.Contains(imageName))
            {
                using (WebClient wc = new WebClient())
                {
                    byte[] getBytes = wc.DownloadData(string.Format(ConfigManager.ServerDownloadImagePath,imageName));
                    if (getBytes.Length == 0)
                        return null;
                    imageDictionary.Add(imageName, getBytes);
                }
            }
            using (MemoryStream ms = new MemoryStream(imageDictionary[imageName]))
            {
                ms.Write(imageDictionary[imageName], 0, imageDictionary[imageName].Length);
                return Image.FromStream(ms, true);
            }
        }
    }
}
