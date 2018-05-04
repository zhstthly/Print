using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting.Models
{
    public class DataBlockModel
    {
        public Guid DataModelID { get; set; }
        public Guid TemplateModelID { get; set; }
        public int ColumnWidth { get; set; }
        public string ColumnName { get; set; }
        public string DataName { get; set; }
        public int Index { get; set; }

        public static DataBlockModel CreateNewInstance()
        {
            return new DataBlockModel()
            {
                DataModelID = Guid.NewGuid(),
                TemplateModelID = new Guid(),
                ColumnWidth = 20,
                ColumnName = "[列名]",
                DataName = "[数据名]"
            };
        }
    }
}
