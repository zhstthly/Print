using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ConfigInfo
    {
        /// <summary>
        /// 公司ID
        /// </summary>
        public string CompanyId
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WarehouseId
        {
            get;
            set;
        }

        /// <summary>录入发票券公司
        /// </summary>
        public string InvoiceFilialeId { get; set; }
        public int OrderType { get; set; }
        public Guid PrintOrderModel { get; set; }

        public List<PrintPlatformSetModel> PrintPlatformSetModelList { get; set; }
        public List<ExpressAutoPrintDTO> ExpList { get; set; }

    }
}
