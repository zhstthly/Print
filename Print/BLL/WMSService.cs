using DataEntity;
using Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WMSService
    {
        static WMSService currentWMSService;
        public static WMSService CurrentWMSService
        {
            get
            {
                if (currentWMSService == null)
                    currentWMSService = new WMSService();
                return currentWMSService;
            }
        }
        private const String _apiControllerName = "Print";
        private const String ERROR_MSG = "网络连接异常，请稍后再试！";
        private const String PARAMETER_MSG = "参数验证异常，请检查参数是否完整！";
        private static List<OrderPrintDataDTO> wmsGroupOrder;

        /// <summary> 缓存按快递公司分组的订单(WMS),内key为下货单号
        /// </summary>
        public static List<OrderPrintDataDTO> WMSGroupOrder
        {
            set
            {
                if (WMSGroupOrder.Count > 0)
                    throw new Exception("之前有未打印完的订单，无法获取");
                SerializationHelper.XmlSerialize(value, ConfigManager.CaCheDatasFilePath);
                wmsGroupOrder = value;
            }
            get
            {
                if(wmsGroupOrder == null)
                {
                    if (File.Exists(ConfigManager.CaCheDatasFilePath))
                        wmsGroupOrder = SerializationHelper.XmlDeserializeFromFile(typeof(List<OrderPrintDataDTO>), ConfigManager.CaCheDatasFilePath)
                            as List<OrderPrintDataDTO>;
                    else
                        return new List<OrderPrintDataDTO>();
                }
                return wmsGroupOrder;
            }
        }

        /// <summary>订单号:用于多少张订单打印一张商品清单(WMS)
        /// </summary>
        public static Dictionary<string, List<OrderPrintDataDTO>> WMSOrderNos = new Dictionary<string, List<OrderPrintDataDTO>>();

        private WMSService()
        {
            
        }

        public static void UpdateCacheData()
        {
            SerializationHelper.XmlSerialize(WMSGroupOrder, ConfigManager.CaCheDatasFilePath);
        }

        #region[加工单]

        /// <summary>框架加工单自动打印获取数据
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="saleFilialeId"></param>
        /// <param name="groupNum"></param>
        /// <returns></returns>
        public List<ProcessOrderPrintDataDTO> AutoPrintProcessOrderBills(Guid warehouseId, Guid saleFilialeId, int groupNum)
        {
            if (warehouseId == default(Guid) || saleFilialeId == default(Guid))
            {
                return new List<ProcessOrderPrintDataDTO>();
            }
            try
            {
                var url = String.Format("{0}?warehouseId={1}&storageType={2}&saleFilialeId={3}&groupNum={4}", 
                    AssembleRequestUrl(_apiControllerName, "AutoPrintProcessOrderBills"), warehouseId, 
                    ConfigManager.StorageType, saleFilialeId, groupNum);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);

                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return new List<ProcessOrderPrintDataDTO>();
                }
                var result = ToObj<ResultInfo<List<ProcessOrderPrintDataDTO>>>(httpResponseMessage);
                if (result.IsSuccess)
                {
                    return result.Data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<ProcessOrderPrintDataDTO>();
        }

        /// <summary>搜索加工单需要打印的下货单数据
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="saleFilialeId"></param>
        /// <param name="processOrderNo"></param>
        /// <returns></returns>
        public ResultInfo<List<ProcessOrderPrintShowDataDTO>> GetProcessOrderData(Guid warehouseId, Guid saleFilialeId, string processOrderNo)
        {
            if (warehouseId == default(Guid) || saleFilialeId == default(Guid) || string.IsNullOrWhiteSpace(processOrderNo))
            {
                return ResultInfo<List<ProcessOrderPrintShowDataDTO>>.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?warehouseId={1}&storageType={2}&saleFilialeId={3}&processOrderNo={4}", AssembleRequestUrl(_apiControllerName, "GetProcessOrderData"), warehouseId, ConfigManager.StorageType, saleFilialeId, processOrderNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<List<ProcessOrderPrintShowDataDTO>>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<List<ProcessOrderPrintShowDataDTO>>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<List<ProcessOrderPrintShowDataDTO>>.Fail(ex.Message);
            }
        }

        /// <summary>获取加工单对应的下货单信息用于实际打印
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="saleFilialeId"></param>
        /// <param name="downGoodsBillNo"></param>
        /// <returns></returns>
        public ResultInfo<ProcessOrderPrintDataDTO> GetPrintProcessOrderBill(Guid warehouseId, Guid saleFilialeId, string downGoodsBillNo)
        {
            if (warehouseId == default(Guid) || saleFilialeId == default(Guid) || string.IsNullOrWhiteSpace(downGoodsBillNo))
            {
                return ResultInfo<ProcessOrderPrintDataDTO>.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?warehouseId={1}&storageType={2}&saleFilialeId={3}&DownGoodsBillNo={4}", AssembleRequestUrl(_apiControllerName, "GetPrintProcessOrderBill"), warehouseId, ConfigManager.StorageType, saleFilialeId, downGoodsBillNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<ProcessOrderPrintDataDTO>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<ProcessOrderPrintDataDTO>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<ProcessOrderPrintDataDTO>.Fail(ex.Message);
            }
        }

        #endregion

        #region[订单]

        /// <summary>自动打印订单下货单数据
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="saleFilialeId"></param>
        /// <param name="salePlatformIds"></param>
        /// <param name="expressIds"></param>
        /// <param name="isPrintInvoice"></param>
        /// <param name="topNum"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public ResultInfo<List<OrderPrintDataDTO>> AutoPrintOrderBills(Guid warehouseId, Guid saleFilialeId, List<Guid> salePlatformIds, List<Guid> expressIds, Boolean isPrintInvoice, int topNum, int orderType)
        {
            if (warehouseId == default(Guid) || saleFilialeId == default(Guid) || salePlatformIds.Count == 0 || expressIds.Count == 0)
            {
                return ResultInfo<List<OrderPrintDataDTO>>.Fail(PARAMETER_MSG);
            }
            var printBillsRequest = new PrintBillsRequest
            {
                WarehouseId = warehouseId,
                SaleFilialeId = saleFilialeId,
                SalePlatformIds = salePlatformIds,
                ExpressIds = expressIds,
                IsAutoPrintInvoice = isPrintInvoice,
                StorageType = ConfigManager.StorageType,
                TopNum = topNum == 0 ? 1000 : topNum,
                OrderType = (byte)orderType
            };
            try
            {
                var url = String.Format("{0}", AssembleRequestUrl(_apiControllerName, "AutoPrintOrderBills"));
                var httpResponseMessage = GetApiRequestJsonResultWithParmas(url, ToJson(printBillsRequest));
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<List<OrderPrintDataDTO>>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<List<OrderPrintDataDTO>>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<List<OrderPrintDataDTO>>.Fail(ex.Message);
            }
        }

        /// <summary>订单手动打印 获取打印数据显示
        /// </summary>
        /// <param name="warehouseId">仓库</param>
        /// <param name="saleFilialeId">托管公司</param>
        /// <param name="outGoodsBillNo">出货单号</param>
        /// <returns></returns>
        public ResultInfo<List<OrderPrintShowDataDTO>> GetOrderPrintShowData(Guid warehouseId, Guid saleFilialeId, string outGoodsBillNo)
        {
            if (warehouseId == default(Guid) || saleFilialeId == default(Guid) || string.IsNullOrWhiteSpace(outGoodsBillNo))
            {
                return ResultInfo<List<OrderPrintShowDataDTO>>.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?warehouseId={1}&storageType={2}&saleFilialeId={3}&outGoodsBillNo={4}", AssembleRequestUrl(_apiControllerName, "GetOrderPrintShowData"), 
                    warehouseId, ConfigManager.StorageType, saleFilialeId, outGoodsBillNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<List<OrderPrintShowDataDTO>>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<List<OrderPrintShowDataDTO>>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<List<OrderPrintShowDataDTO>>.Fail(ex.Message);
            }
        }

        /// <summary>订单下货单（出货单）打印数据
        /// </summary>
        /// <param name="warehouseId">仓库</param>
        /// <param name="saleFilialeId">托管公司</param>
        /// <param name="downGoodsBillNo">下货单</param>
        /// <returns></returns>
        public ResultInfo<OrderPrintDataDTO> GetPrintOrderBill(Guid warehouseId, Guid saleFilialeId, string downGoodsBillNo)
        {
            if (warehouseId == default(Guid) || saleFilialeId == default(Guid) || string.IsNullOrWhiteSpace(downGoodsBillNo))
            {
                return ResultInfo<OrderPrintDataDTO>.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?warehouseId={1}&storageType={2}&saleFilialeId={3}&DownGoodsBillNo={4}", AssembleRequestUrl(_apiControllerName, "GetPrintOrderBill"), warehouseId, ConfigManager.StorageType, saleFilialeId, downGoodsBillNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<OrderPrintDataDTO>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<OrderPrintDataDTO>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<OrderPrintDataDTO>.Fail(ex.Message);
            }
        }

        /// <summary>订单下货单（出货单）日志打印
        /// </summary>
        /// <param name="downGoodsBillNo">下货单</param>
        /// <returns></returns>
        public ResultInfo<OrderPrintDataDTO> LogPrintOrderBill(string downGoodsBillNo)
        {
            if (string.IsNullOrWhiteSpace(downGoodsBillNo))
            {
                return ResultInfo<OrderPrintDataDTO>.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?downGoodsBillNo={1}", AssembleRequestUrl(_apiControllerName, "LogPrintOrderBill"), downGoodsBillNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<OrderPrintDataDTO>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<OrderPrintDataDTO>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<OrderPrintDataDTO>.Fail(ex.Message);
            }
        }

        /// <summary>未打印的记录重置
        /// </summary>
        /// <param name="downGoodsBillNos">下货单</param>
        /// <returns></returns>
        public static ResultInfo NoPrintedResetReaderId(List<string> downGoodsBillNos)
        {
            if (downGoodsBillNos == null || downGoodsBillNos.Count == 0)
            {
                return ResultInfo.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}", AssembleRequestUrl(_apiControllerName, "NoPrintedResetReaderId"));
                var httpResponseMessage = GetApiRequestJsonResultWithParmas(url, ToJson(downGoodsBillNos));
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo.Fail(ex.Message);
            }
        }

        /// <summary>生成总单号
        /// </summary>
        /// <returns></returns>
        public static string GeneratePrintTotalBillNo()
        {
            try
            {
                var url = String.Format("{0}", AssembleRequestUrl(_apiControllerName, "GeneratePrintTotalBillNo"));
                var httpResponseMessage = GetApiRequestJsonResultWith(url);
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return string.Empty;
                }
                var result = ToObj<ResultInfo<string>>(httpResponseMessage);
                if (result != null && result.IsSuccess)
                {
                    return result.Data;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion

        #region[打包扫描，打印快递单]

        /// <summary>打印电子面单时获取出货单信息
        /// </summary>
        /// <param name="outGoodsBillNo">出货单</param>
        /// <returns></returns>
        public ResultInfo<OrderPrintDataDTO> PrintExpressBillGetOrderBill(string outGoodsBillNo)
        {
            if (string.IsNullOrWhiteSpace(outGoodsBillNo))
            {
                return ResultInfo<OrderPrintDataDTO>.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?outGoodsBillNo={1}", AssembleRequestUrl(_apiControllerName, "PrintExpressBillGetOrderBill"), outGoodsBillNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);

                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<OrderPrintDataDTO>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<OrderPrintDataDTO>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<OrderPrintDataDTO>.Fail(ex.Message);
            }
        }

        /// <summary>配货检查业务处理
        /// </summary>
        /// <param name="outGoodsBillNo"></param>
        /// <param name="expressNo"></param>
        /// <param name="operatorId"></param>
        /// <param name="operatorName"></param>
        /// <returns></returns>
        public ResultInfo CargoCheck(string outGoodsBillNo, string expressNo, Guid operatorId, string operatorName)
        {
            if (string.IsNullOrWhiteSpace(outGoodsBillNo))
            {
                return ResultInfo.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?outGoodsBillNo={1}&expressNo={2}&operatorId={3}&operatorName={4}", AssembleRequestUrl(_apiControllerName, "CargoCheck"), outGoodsBillNo, expressNo, operatorId, operatorName);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);

                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo.Fail(ex.Message);
            }
        }

        /// <summary>是否需要录入快递号和获取订单提示
        /// </summary>
        /// <param name="outGoodsBillNo"></param>
        /// <returns></returns>
        public ResultInfo<KeyValuePair<bool, string>> IsWriteExpressNoAndGetOrderHint(string outGoodsBillNo)
        {
            if (string.IsNullOrWhiteSpace(outGoodsBillNo))
            {
                return ResultInfo<KeyValuePair<bool, string>>.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?outGoodsBillNo={1}", AssembleRequestUrl(_apiControllerName, "IsWriteExpressNoAndGetOrderHint"), outGoodsBillNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);

                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<KeyValuePair<bool, string>>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<KeyValuePair<bool, string>>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<KeyValuePair<bool, string>>.Fail(ex.Message);
            }
        }

        /// <summary>更新订单提示为已读
        /// </summary>
        /// <param name="outGoodsBillNo"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        public ResultInfo SetOrderHintMarkRead(string outGoodsBillNo, string reader)
        {
            if (string.IsNullOrWhiteSpace(outGoodsBillNo))
            {
                return ResultInfo.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?outGoodsBillNo={1}&reader={2}", AssembleRequestUrl(_apiControllerName, "SetOrderHintMarkRead"), outGoodsBillNo, reader);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);

                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo.Fail(ex.Message);
            }
        }

        /// <summary>获取菜鸟快递面单打印信息
        /// </summary>
        /// <param name="outGoodsBillNo">出货单号</param>
        /// <returns></returns>
        public ResultInfo<WaybillApplyDTO> GetWaybillApply(string outGoodsBillNo)
        {
            if (string.IsNullOrWhiteSpace(outGoodsBillNo))
            {
                return ResultInfo<WaybillApplyDTO>.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?outGoodsBillNo={1}", AssembleRequestUrl(_apiControllerName, "GetWaybillApply"), outGoodsBillNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);

                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<WaybillApplyDTO>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<WaybillApplyDTO>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<WaybillApplyDTO>.Fail(ex.Message);
            }
        }

        /// <summary>获取直连快递面单打印信息
        /// </summary>
        /// <param name="outGoodsBillNo">出货单号</param>
        /// <returns></returns>
        public ResultInfo<OrderPrintMessageDTO> GetOrderPrintMessage(string outGoodsBillNo)
        {
            if (string.IsNullOrWhiteSpace(outGoodsBillNo))
            {
                return ResultInfo<OrderPrintMessageDTO>.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?outGoodsBillNo={1}", AssembleRequestUrl(_apiControllerName, "GetOrderPrintMessage"), outGoodsBillNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);

                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<OrderPrintMessageDTO>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<OrderPrintMessageDTO>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<OrderPrintMessageDTO>.Fail(ex.Message);
            }
        }

        #endregion

        public Dictionary<string, string> GetExpressDic(Guid warehouseId)
        {
            var result = GetExpressByWarehouseId(warehouseId);
            if (result.IsSuccess)
            {
                return result.Data.ToDictionary(ent => ent.ExpressId.ToString(), ent => ent.ExpressName);
            }
            return new Dictionary<string, string>();
        }

        /// <summary>打印完毕记录回传
        /// </summary>
        /// <param name="downGoodsBillNo">下货单</param>
        /// <returns></returns>
        public ResultInfo RecordPrinted(string downGoodsBillNo)
        {
            if (string.IsNullOrWhiteSpace(downGoodsBillNo))
            {
                return ResultInfo.Fail(PARAMETER_MSG);
            }
            try
            {
                var url = String.Format("{0}?downGoodsBillNo={1}", AssembleRequestUrl(_apiControllerName, "RecordPrinted"), downGoodsBillNo);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);

                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo.Fail(ex.Message);
            }
        }

        /// <summary>自动打印记录回传
        /// </summary>
        /// <param name="recordsPrintedRequest"></param>
        /// <returns></returns>
        public ResultInfo RecordsPrinted(RecordsPrintedRequest recordsPrintedRequest)
        {
            try
            {
                var url = String.Format("{0}", AssembleRequestUrl(_apiControllerName, "RecordsPrinted"));
                var httpResponseMessage = GetApiRequestJsonResultWithParmas(url, ToJson(recordsPrintedRequest));
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo.Fail(ex.Message);
            }
        }

        /// <summary>获取所有使用的仓库
        /// </summary>
        /// <returns></returns>
        public ResultInfo<Dictionary<Guid, string>> GetAllUseWarehouse()
        {
            try
            {
                var url = String.Format("{0}", AssembleRequestUrl(_apiControllerName, "GetAllUseWarehouse"));
                var httpResponseMessage = GetApiRequestJsonResultWith(url);
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<Dictionary<Guid, string>>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<Dictionary<Guid, string>>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<Dictionary<Guid, string>>.Fail(ex.Message);
            }
        }

        /// <summary>根据仓库获取仓库下启用的快递公司
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns></returns>
        public ResultInfo<List<PrintExpressDTO>> GetExpressByWarehouseId(Guid warehouseId)
        {
            try
            {
                var url = String.Format("{0}?WarehouseId={1}", AssembleRequestUrl(_apiControllerName, "GetExpressByWarehouseId"), warehouseId);
                var httpResponseMessage = GetApiRequestJsonResultWith(url);
                if (string.IsNullOrWhiteSpace(httpResponseMessage))
                {
                    return ResultInfo<List<PrintExpressDTO>>.Fail(ERROR_MSG);
                }
                return ToObj<ResultInfo<List<PrintExpressDTO>>>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                return ResultInfo<List<PrintExpressDTO>>.Fail(ex.Message);
            }
        }

        static string AssembleRequestUrl(String controllerName, String methodName)
        {
            return string.Format("{0}{1}/{2}", ConfigManager.ApiUrl, controllerName, methodName);
        }

        /// <summary>获取API请求接口返回的数据
        /// </summary>
        /// <param name="url">URL连接</param>
        /// <param name="parmas">参数，默认空</param>
        /// <returns></returns>
        static String GetApiRequestJsonResultWithParmas(String url, String parmas)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(parmas);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage httpResponseMessage = client.PostAsync(url, content).Result;
                    return httpResponseMessage.Content.ReadAsStringAsync().Result;
                }
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>获取API请求接口返回的数据
        /// </summary>
        /// <param name="url">URL连接</param>
        /// <returns></returns>
        static String GetApiRequestJsonResultWith(String url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage httpResponseMessage = client.PostAsync(url, null).Result;
                    return httpResponseMessage.Content.ReadAsStringAsync().Result;
                }
            }
            catch
            {
                return String.Empty;
            }
        }

        public Dictionary<string, object> GetExtends(string jsonText, params string[] extendkeys)
        {
            if (string.IsNullOrEmpty(jsonText))
                return new Dictionary<string, object>();
            var extends = ToJobj(jsonText);
            if (extends.HasValues)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (string key in extendkeys)
                {
                    if (extends[key] != null)
                        dic.Add(key, extends[key]);
                }
                return dic;
            }
            return new Dictionary<string, object>();
        }

        static JObject ToJobj(string jsonText)
        {
            JObject jobj = (JObject)JsonConvert.DeserializeObject(jsonText);
            return jobj;
        }

        /// <summary>反序列化
        /// </summary>
        /// <param name="jsonText"></param>
        /// <typeparam name="T"></typeparam>
        static T ToObj<T>(string jsonText)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonText);
        }

        /// <summary>序列化
        /// </summary>
        /// <param name="obj"></param>
        static string ToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);

        }
    }
}
