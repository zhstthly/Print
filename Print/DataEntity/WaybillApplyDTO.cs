using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class WaybillApplyDTO
    {
        /// <summary>出货单号
        /// </summary>
        public string OutGoodsBillNo { get; set; }

        /// <summary>快递服务编号（eg：SF,YTO,ZTO,STO）
        /// </summary>
        public string ServiceCode { get; set; }

        /// <summary>集包地名称
        /// </summary>
        public string PackageCenterName { get; set; }

        /// <summary>大头笔
        /// </summary>
        public string ShortAddress { get; set; }

        /// <summary>运单号
        /// </summary>
        public string WaybillCode { get; set; }
    }
}
