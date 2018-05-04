using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting.Models
{
    public class TemplateModel
    {
        public Guid ModelID { get; set; }
        public string ModelName { get; set; }
        public string CompanyName { get; set; }
        public Guid BindingPage { get; set; }
        public static TemplateModel Create()
        {
            return new TemplateModel()
            {
                ModelID = Guid.NewGuid(),
                ModelName = "",
                CompanyName = "",
                BindingPage = new Guid()
            };
        }
    }
}
