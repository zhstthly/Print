using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintEntity
{
    public class DataBlockTemplateModel
    {
        public Guid ModelID { get; set; }
        public string ModelName { get; set; }
        public string FontFamilyName { get; set; }
        public float FontSize { get; set; }
        public int PaddingLeft { get; set; }
        public int PaddingTop { get; set; }
        public int PaddingRight { get; set; }
        public int PaddingBottom { get; set; }
        public int PageWidth { get; set; }
        public int ColumnNum { get; set; }
        public int Distance { get; set; }
        public int LineWidth { get; set; }
        public bool DataSplitter { get; set; }
        public bool Enable { get; set; }
    }
}
