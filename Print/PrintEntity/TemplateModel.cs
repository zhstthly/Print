using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintEntity
{
    public class TemplateModel
    {
        public Guid ModelID { get; set; }
        public string ModelName { get; set; }
        public string CompanyName { get; set; }
        public Guid BindingPage { get; set; }
    }
}
