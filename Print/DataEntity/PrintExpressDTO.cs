using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class PrintExpressDTO
    {
        /// <summary>快递ID
        /// </summary>
        public Guid ExpressId { get; set; }

        /// <summary>快递名称（快递简称[支付方式]）
        /// </summary>
        public string ExpressName { get; set; }

        /// <summary>是否允许自动打印快递面单（菜鸟，直连，京东快递接口不允许自动打印快递面单）
        /// </summary>
        public bool IsAllowAutoPrintExpressBill { get; set; }

        /// <summary>
        /// 面单类型。参见枚举ExpressSurfaceType
        /// </summary>
        public byte ExpressSurfaceType { get; set; }

        /// <summary>
        /// 快递产品服务类型。参见枚举ExpressProductType
        /// </summary>
        public byte ExpressProductType { get; set; }

        /// <summary>
        /// 快递服务编码类型。参见枚举ExpressServiceCodeType
        /// </summary>
        public byte ExpressServiceCodeType { get; set; }
    }
}
