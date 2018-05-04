using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    /// <summary>
    /// 打印公司设置模型
    /// </summary>
    public class PrintPlatformSetModel
    {
        /// <summary>
        /// 销售公司ID
        /// </summary>
        public Guid SalePlatformId { get; set; }

        /// <summary>
        /// 是否对该销售公司的订单是否处理
        /// </summary>
        public Boolean IsProcess { get; set; }
    }
}
