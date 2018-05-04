using BLL.Models;
using Infrastructure;
using Newtonsoft.Json;
using PrintFieldsLocationSetting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting
{
    public class PrintDatas
    {
        //数据字段和打印字段关系列表
        public static List<PrintFieldsBindingModel> PrintFieldBM = new List<PrintFieldsBindingModel>();
        //打印模板列表
        public static List<TemplateModel> templateMList = new List<TemplateModel>();
        //打印字段列表
        public static List<FieldModel> fieldModelList = new List<FieldModel>();
        //打印纸张列表
        public static List<PageModel> pageMList = new List<PageModel>();
        //数据块模板列表
        public static List<DataBlockTemplateModel> dataBlockTMList = new List<DataBlockTemplateModel>();
        //数据块列表
        public static List<DataBlockModel> dataBlockMList = new List<DataBlockModel>();
        //图片分类列表（快递单）
        public static List<PictureGroupModel> pictureGroupMList = new List<PictureGroupModel>();
        //图片位置列表（快递单）
        public static List<PictureLocationModel> pictureLocationMList = new List<PictureLocationModel>();
        //图片分类和位置列表（快递单）
        public static List<PictureGroupLocationModel> pictureGroupLocationMList = new List<PictureGroupLocationModel>();
        //销售平台底部图片（快递单）[业务]
        public static List<SaleCompanyDTO> saleCompanyMList = new List<SaleCompanyDTO>();
        //寄件人信息
        public static List<PrintSenderDTO> printSenderDTOList = new List<PrintSenderDTO>();

        public static void DeleteImage(string imageName)
        {
            //上传到服务器
            using (WebClient wc = new WebClient())
            {
                wc.UploadString(string.Format(ConfigManager.ServerDeleteImagePath, imageName), "DELETE", "");
            }
        }

        public static void UploadFile(string imagePath,string imageName)
        {
            //上传到服务器
            using (WebClient wc = new WebClient())
            {
                wc.UploadFile(string.Format(ConfigManager.ServerUpLoadImagePath,imageName), imagePath);
            }
        }

        public static void SyncDataToServer()
        {
            //上传到服务器
            using (WebClient wc = new WebClient())
            {
                //上传打印模板数据
                string jsonString = JsonConvert.SerializeObject(templateMList);
                byte[] objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                byte[] fileb = wc.UploadData(ConfigManager.ServerTemplateModelPath, "PUT", objectContent);

                //上传打印字段数据
                jsonString = JsonConvert.SerializeObject(fieldModelList.ToList());
                objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                fileb = wc.UploadData(ConfigManager.ServerFieldModelPath, "PUT", objectContent);

                //上传打印纸张数据
                jsonString = JsonConvert.SerializeObject(pageMList);
                objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                fileb = wc.UploadData(ConfigManager.ServerPageModelPath, "PUT", objectContent);

                //上传数据块模板数据
                jsonString = JsonConvert.SerializeObject(dataBlockTMList);
                objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                fileb = wc.UploadData(ConfigManager.ServerDataBlockTemplateModelPath, "PUT", objectContent);

                //上传数据块数据
                jsonString = JsonConvert.SerializeObject(dataBlockMList);
                objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                fileb = wc.UploadData(ConfigManager.ServerDataBlockModelPath, "PUT", objectContent);

                //上传图片组数据
                jsonString = JsonConvert.SerializeObject(pictureGroupMList);
                objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                fileb = wc.UploadData(ConfigManager.ServerPictureGroupModelPath, "PUT", objectContent);

                //上传图片标识数据
                jsonString = JsonConvert.SerializeObject(pictureLocationMList);
                objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                fileb = wc.UploadData(ConfigManager.ServerPictureLocationModelPath, "PUT", objectContent);

                //上传图片组标识数据
                jsonString = JsonConvert.SerializeObject(pictureGroupLocationMList);
                objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                fileb = wc.UploadData(ConfigManager.ServerPictureGroupLocationModelPath, "PUT", objectContent);

                //上传销售平台数据
                jsonString = JsonConvert.SerializeObject(saleCompanyMList);
                objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                fileb = wc.UploadData(ConfigManager.ServerSaleCompanyModelPath, "PUT", objectContent);

                //上传寄件人数据
                jsonString = JsonConvert.SerializeObject(printSenderDTOList);
                objectContent = Encoding.UTF8.GetBytes(jsonString);
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add("Content-Type", "application/json");
                fileb = wc.UploadData(ConfigManager.ServerPrintSenderDTOPath, "PUT", objectContent);
            }
        }

        public static void SyncDataFromServer()
        {
            //从服务器上同步数据
            using (WebClient wc = new WebClient())
            {
                //获取打印模板数据
                byte[] getBytes = wc.DownloadData(ConfigManager.ServerTemplateModelPath);
                templateMList = JsonConvert.DeserializeObject<List<TemplateModel>>(Encoding.UTF8.GetString(getBytes));

                //获取打印字段数据
                getBytes = wc.DownloadData(ConfigManager.ServerFieldModelPath);
                fieldModelList = JsonConvert.DeserializeObject<List<FieldModel>>(Encoding.UTF8.GetString(getBytes));

                //获取打印纸张数据
                getBytes = wc.DownloadData(ConfigManager.ServerPageModelPath);
                pageMList = JsonConvert.DeserializeObject<List<PageModel>>(Encoding.UTF8.GetString(getBytes));

                //获取打印字段和模板字段绑定数据
                getBytes = wc.DownloadData(ConfigManager.ServerPrintFieldsBindingPath);
                PrintFieldBM = JsonConvert.DeserializeObject<List<PrintFieldsBindingModel>>(Encoding.UTF8.GetString(getBytes)).OrderBy(p => p.PrintName).ToList();

                //获取数据块模板数据
                getBytes = wc.DownloadData(ConfigManager.ServerDataBlockTemplateModelPath);
                dataBlockTMList = JsonConvert.DeserializeObject<List<DataBlockTemplateModel>>(Encoding.UTF8.GetString(getBytes));

                //获取数据块数据
                getBytes = wc.DownloadData(ConfigManager.ServerDataBlockModelPath);
                dataBlockMList = JsonConvert.DeserializeObject<List<DataBlockModel>>(Encoding.UTF8.GetString(getBytes));

                //获取图片组数据
                getBytes = wc.DownloadData(ConfigManager.ServerPictureGroupModelPath);
                pictureGroupMList = JsonConvert.DeserializeObject<List<PictureGroupModel>>(Encoding.UTF8.GetString(getBytes));

                //获取图片标识数据
                getBytes = wc.DownloadData(ConfigManager.ServerPictureLocationModelPath);
                pictureLocationMList = JsonConvert.DeserializeObject<List<PictureLocationModel>>(Encoding.UTF8.GetString(getBytes));

                //获取图片组标识数据
                getBytes = wc.DownloadData(ConfigManager.ServerPictureGroupLocationModelPath);
                pictureGroupLocationMList = JsonConvert.DeserializeObject<List<PictureGroupLocationModel>>(Encoding.UTF8.GetString(getBytes));

                //获取销售平台数据
                getBytes = wc.DownloadData(ConfigManager.ServerSaleCompanyModelPath);
                saleCompanyMList = JsonConvert.DeserializeObject<List<SaleCompanyDTO>>(Encoding.UTF8.GetString(getBytes));

                //获取销售平台数据
                getBytes = wc.DownloadData(ConfigManager.ServerPrintSenderDTOPath);
                printSenderDTOList = JsonConvert.DeserializeObject<List<PrintSenderDTO>>(Encoding.UTF8.GetString(getBytes));
            }
        }
    }
}
