using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class ExpressAutoPrintDTO
    {
        public bool Selected { get; set; }
        public bool AutoPrint { get; set; }
        public Guid ExpressCompanyId { get; set; }
        public Guid ExpressPrintModel { get; set; }
        public string OrderPrinter { get; set; }
        public string ExpressPrinter { get; set; }
        public Guid PictureGroup { get; set; }
    }
}
