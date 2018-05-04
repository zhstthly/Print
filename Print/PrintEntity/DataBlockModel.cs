using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintEntity
{
    public class DataBlockModel
    {
        public Guid DataModelID { get; set; }
        public Guid TemplateModelID { get; set; }
        public int ColumnWidth { get; set; }
        public string ColumnName { get; set; }
        public string DataName { get; set; }
        public int Index { get; set; }
    }
}
