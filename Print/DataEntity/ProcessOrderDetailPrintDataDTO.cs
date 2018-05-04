using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class ProcessOrderDetailPrintDataDTO
    {
        /// <summary>货位号
        /// </summary>
        public string BinNo { get; set; }

        /// <summary>货位盒子号
        /// </summary>
        public string BoxNo { get; set; }

        /// <summary>商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>规格
        /// </summary>
        public string Sku { get; set; }
    }
}
