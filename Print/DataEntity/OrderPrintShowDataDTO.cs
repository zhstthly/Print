using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class OrderPrintShowDataDTO
    {
        /// <summary>出货单
        /// </summary>
        public string OutGoodsBillNo { get; set; }

        /// <summary>多个订单号合并逗号分开
        /// </summary>
        public string OrderNos { get; set; }

        /// <summary>下货单号
        /// </summary>
        public string DownGoodsBillNo { get; set; }

        /// <summary>下货单状态
        /// </summary>
        public string DownGoodsBillState { get; set; }

        /// <summary>出货单状态
        /// </summary>
        public string OutGoodsBillState { get; set; }

        /// <summary>出货时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>收货人
        /// </summary>
        public string Consignee { get; set; }

        /// <summary>手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>快递公司
        /// </summary>
        public string ExpressName { get; set; }

        /// <summary>收件地址
        /// </summary>
        public String Direction { get; set; }

        /// <summary>快递ID
        /// </summary>
        public Guid ExpressId { get; set; }
    }
}
