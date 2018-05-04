using DataEntity;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ConfigManager
    {
        const string serverPath = "http://192.168.117.132:8080/api/";
        const string uiApiUrl = "http://192.168.117.132:8081/api/";
        const string apiUrl = "http://192.168.117.132:8082/api/";
        //const string apiUrl = "http://192.168.117.39:3005/api/";
        //const string apiUrl = "http://apiwms.kede.com/api/";
        const string configXmlName = "config.xml";
        const byte storageType = 2;
        static ConfigInfo configInfo;
        public static readonly string ImageApiAction = "UploadImage/QRCodeImage?imageName={0}";
        public static readonly string EInvoiceUrlFormatStringApiAction = "QRCode/EInvoiceUrlFormatString";
        public static readonly string DownLoadFileUriApiAction = "QRCode/DownLoadFileUri";
        static readonly string CacheDatasFileName = "PrintDatas.xml";
        static string baseLocalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles");

        public static string CaCheDatasFilePath
        {
            get { return Path.Combine(baseLocalPath, CacheDatasFileName); }
        }

        static string ConfigPath
        {
            get { return Path.Combine(baseLocalPath, configXmlName); }
        }

        public static string ServerPrintSenderDTOPath
        {
            get
            {
                return Path.Combine(serverPath, "Print/PrintSenderDTO");
            }
        }

        public static string ServerPictureGroupPath
        {
            get
            {
                return Path.Combine(serverPath, "Print/PictureGroupModel");
            }
        }

        public static string ServerDownloadImagePath
        {
            get
            {
                return Path.Combine(serverPath, "Print/DownloadImage?imageName={0}");
            }
        }

        public static string ServerTemplateModelPath
        {
            get
            {
                return Path.Combine(serverPath, "Print/TemplateModel");
            }
        }

        public static string ServerFieldModelPath
        {
            get
            {
                return Path.Combine(serverPath, "Print/FieldModel");
            }
        }

        public static string ServerPageModelPath
        {
            get
            {
                return Path.Combine(serverPath, "Print/PageModel");
            }
        }

        public static string ServerPrintFieldsBindingPath
        {
            get
            {
                return Path.Combine(serverPath, "Print/PrintFieldsBinding");
            }
        }

        public static string ServerDataBlockTemplateModelPath
        {
            get
            {
                return Path.Combine(serverPath, "Print/DataBlockTemplateModel");
            }
        }

        public static string ServerDataBlockModelPath
        {
            get
            {
                return Path.Combine(serverPath, "Print/DataBlockModel");
            }
        }

        public static string ApiUrl
        {
            get
            {
                return apiUrl;
            }
        }

        public static byte StorageType
        {
            get
            {
                return storageType;
            }
        }

        public static ConfigInfo ConfigInfo
        {
            get
            {
                if(configInfo == null)
                {
                    if (!Directory.Exists(baseLocalPath))
                        Directory.CreateDirectory(baseLocalPath);
                    if (!File.Exists(ConfigPath))
                    {
                        SerializationHelper.XmlSerialize(new ConfigInfo(), ConfigPath);
                        return new ConfigInfo();
                    }
                    configInfo = SerializationHelper.XmlDeserializeFromFile(typeof(ConfigInfo), ConfigPath) as ConfigInfo;
                }
                return configInfo;
            }
        }

        public static void SaveConfig()
        {
            SerializationHelper.XmlSerialize(configInfo, ConfigPath);
        }
    }
}
