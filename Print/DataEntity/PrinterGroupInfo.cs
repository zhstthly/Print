using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    /// <summary>
    /// 打印机组信息
    /// </summary>
    [Serializable]
    public class PrinterGroupInfo
    {
        /// <summary>
        /// 打印机组ID
        /// </summary>
        public string PrinterGroupId { get; set; }

        /// <summary>
        /// 打印机组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 快递打印机
        /// </summary>
        public string ExpressPrinter { get; set; }

        /// <summary>
        /// 订单打印机
        /// </summary>
        public string OrderPrinter { get; set; }

        /// <summary>
        /// 商品清单打印机
        /// </summary>
        public string ListPrinter { get; set; }

        /// <summary>
        /// 订单模版
        /// </summary>
        //public string OrdTemplate { get; set; }

        /// <summary>
        /// 快递模版
        /// </summary>
        public string ExpTmplId { get; set; }

        /// <summary>
        /// 发票模板
        /// </summary>
        public string InvoiceId { get; set; }

    }
}
