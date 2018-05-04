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
        //要在配置中心取
        const string ServerPath = "http://localhost:8978/api/";

        public static string ServerPrintSenderDTOPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/PrintSenderDTO");
            }
        }

        public static string ServerSaleCompanyModelPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/SaleCompanyModel");
            }
        }

        public static string ServerDeleteImagePath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/DeleteImage?imageName={0}");
            }
        }

        public static string ServerUpLoadImagePath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/UploadImage?imageName={0}");
            }
        }

        public static string ServerTemplateModelPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/TemplateModel");
            }
        }

        public static string ServerFieldModelPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/FieldModel");
            }
        }

        public static string ServerPageModelPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/PageModel");
            }
        }

        public static string ServerPrintFieldsBindingPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/PrintFieldsBinding");
            }
        }

        public static string ServerDataBlockTemplateModelPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/DataBlockTemplateModel");
            }
        }

        public static string ServerDataBlockModelPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/DataBlockModel");
            }
        }

        public static string ServerPictureGroupLocationModelPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/PictureGroupLocationModel");
            }
        }

        public static string ServerPictureGroupModelPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/PictureGroupModel");
            }
        }

        public static string ServerPictureLocationModelPath
        {
            get
            {
                return Path.Combine(ServerPath, "Print/PictureLocationModel");
            }
        }
    }
}
