using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting.Models
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

        public static DataBlockTemplateModel CreateNewInstance(string modelName,string fontFamilyName,float fontSize,
            int pageWidth,int columnNum,int distance,int lineWidth,int paddingLeft,int paddingTop,
            int paddingRight,int paddingBottom)
        {
            return new DataBlockTemplateModel()
            {
                ModelID = Guid.NewGuid(),
                FontFamilyName = fontFamilyName,
                FontSize = fontSize,
                ModelName = modelName,
                PageWidth = pageWidth,
                DataSplitter = true,
                ColumnNum = columnNum,
                Enable = true,
                Distance = distance,
                LineWidth = lineWidth,
                PaddingLeft = paddingLeft,
                PaddingTop = paddingTop,
                PaddingRight = paddingRight,
                PaddingBottom = paddingBottom
            };
        }
    }
}
