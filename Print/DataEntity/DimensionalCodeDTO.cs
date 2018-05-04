using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class DimensionalCodeDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string MessageButton { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MessageTop { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImageFileName { get; set; }

        public bool IsEnable { get; set; }

        public bool PrintEInvoice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EInvoice { get; set; }

        /// <summary>
        /// 扩展字段，保存其他扩展属性
        /// </summary>
        public string Extends { get; set; }
    }
}
