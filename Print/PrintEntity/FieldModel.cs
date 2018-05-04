using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintEntity
{
    public class FieldModel
    {
        public FieldType FieldType { get; set; }
        public PrintType PrintType { get; set; }
        public Guid ModelID { get; set; }
        public Guid FieldID { get; set; }
        public string FieldName { get; set; }
        public string BindingText { get; set; }
        public bool Enable { get; set; }
        public string FontFamilyName { get; set; }
        public decimal FontSize { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int TextAreaWidth { get; set; }
        public int TextAreaHeight { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
    }

    public enum FieldType
    {
        String,
        Image,
        BarCode,
        DataBlock,
        Line
    }

    public enum PrintType
    {
        Dynamic,
        Static
    }
}
