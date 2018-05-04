using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class PrintSenderDTO
    {
        public Guid ID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid SalePlatformID { get; set; }
        public string Sender { get; set; }
        public string Signature { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Departure { get; set; }
        public string WebSite { get; set; }
        public string Address { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string CompanyName { get; set; }
        public string GlassFooter { get; set; }
    }
}
