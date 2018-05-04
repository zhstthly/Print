using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class PrintBillsRequest
    {
        /// <summary> 仓库ID
        /// </summary>
        public Guid WarehouseId { get; set; }

        /// <summary>储位
        /// </summary>
        public byte StorageType { get; set; }

        /// <summary>托管公司ID
        /// </summary>
        public Guid SaleFilialeId { get; set; }

        /// <summary>销售平台ID
        /// </summary>
        public List<Guid> SalePlatformIds { get; set; }

        /// <summary>快递公司ID
        /// </summary>
        public List<Guid> ExpressIds { get; set; }

        /// <summary>是否打印发票
        /// </summary>
        public bool IsAutoPrintInvoice { get; set; }

        /// <summary>
        /// </summary>
        public int TopNum { get; set; }

        public byte OrderType { get; set; }
    }
}
