using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class OrderPrintMessageDTO
    {
        /// <summary>出货单号
        /// </summary>
        public string OutGoodsBillNo { get; set; }

        /// <summary> 运单号（快递单号）
        /// </summary>
        public string MailNo { get; set; }

        /// <summary>顺丰原寄地代码
        /// </summary>
        public string SFOriginCode { get; set; }

        /// <summary>顺丰目的地代码
        /// </summary>
        public string SFDestCode { get; set; }

        /// <summary>顺丰商家编号
        /// </summary>
        public string SFCustId { get; set; }

        /// <summary>第三方订单号（京东订单号）
        /// </summary>
        public string ThrOrderNo { get; set; }

        /// <summary>第三方订单实际应付金额（京东order_payment）
        /// </summary>
        public double? ThrOrderRealTotalPrice { get; set; }
    }
}
