using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class ProcessOrderPrintDataDTO
    {
        public string OrderNos { get; set; }
        /// <summary>下货单号
        /// </summary>
        public string DownGoodsBillNo { get; set; }

        /// <summary>加工单号
        /// </summary>
        public string ProcessOrderNo { get; set; }

        /// <summary>出货单号
        /// </summary>
        public string OutGoodsBillNo { get; set; }

        /// <summary>加工单来源公司名称
        /// </summary>
        public string FromFilialeName { get; set; }

        /// <summary>收货人
        /// </summary>
        public string Consignee { get; set; }

        /// <summary>打印盒子号
        /// </summary>
        public int PrintBoxNo { get; set; }

        public bool IsSingleFrame { get; set; }

        /// <summary>加工单明细
        /// </summary>
        public List<ProcessOrderDetailPrintDataDTO> ProcessOrderDetailPrintDataDtos { get; set; }

        public DimensionalCodeDTO DimensionalCodeDto { get; set; }

        //销售平台id
        public string SalePlatformId { get; set; }
    }
}
