using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting.Models
{
    public class PrintFieldsBindingModel
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string DataName { get; set; }
        public string PrintName { get; set; }
        public string Description { get; set; }
    }
}
