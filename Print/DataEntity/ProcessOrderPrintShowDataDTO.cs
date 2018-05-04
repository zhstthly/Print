using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class ProcessOrderPrintShowDataDTO
    {
        /// <summary>加工单号
        /// </summary>
        public string ProcessOrderNo { get; set; }

        /// <summary>下货单号
        /// </summary>
        public string DownGoodsBillNo { get; set; }

        /// <summary>下货单状态
        /// </summary>
        public string DownBillState { get; set; }

        /// <summary>加工单操作状态
        /// </summary>
        public string OperateState { get; set; }

        /// <summary>加工单状态
        /// </summary>
        public string ProcessOrderState { get; set; }

        /// <summary>收货人
        /// </summary>
        public string Consignee { get; set; }
    }
}
