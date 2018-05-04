using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintEntity
{
    public class PrintEditResultModel
    {
        public Dictionary<string,object> Extends { get; set; }
        public PageModel PageModel { get; set; }
        public TemplateModel TemplateModel { get; set; }
        public List<FieldModel> Fields { get; set; }
        public List<List<DataBlockMapping>> DataEntity { get; set; }
    }
}
