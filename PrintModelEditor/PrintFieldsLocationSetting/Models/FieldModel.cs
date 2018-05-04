using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting.Models
{
    public class FieldModel
    {
        public Guid ModelID { get; set; }
        public Guid FieldID { get; set; }
        public FieldType FieldType { get; set; }
        public PrintType PrintType { get; set; }
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

        public static FieldModel CreateANewImage(Guid modelId)
        {
            return new FieldModel()
            {
                ModelID = modelId,
                FieldID = Guid.NewGuid(),
                FieldName = "",
                BindingText = "",
                Enable = true,
                FontFamilyName = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontFamilyName,
                FontSize = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontSize,
                FieldType = FieldType.Image,
                PrintType = PrintType.Dynamic,
                TextAreaWidth = 50,
                TextAreaHeight = 50
            };
        }

        public static FieldModel CreateANewBarCode(Guid modelId)
        {
            return new FieldModel()
            {
                ModelID = modelId,
                FieldID = Guid.NewGuid(),
                FieldName = "",
                BindingText = "",
                Enable = true,
                FontFamilyName = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontFamilyName,
                FontSize = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontSize,
                FieldType = FieldType.BarCode,
                PrintType = PrintType.Dynamic,
                TextAreaWidth = 160,
                TextAreaHeight = 30
            };
        }

        public static FieldModel CreateANewSplitter_V(Guid modelId)
        {
            return new FieldModel()
            {
                ModelID = modelId,
                FieldID = Guid.NewGuid(),
                FieldName = "竖线",
                BindingText = "",
                Enable = true,
                FontFamilyName = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontFamilyName,
                FontSize = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontSize,
                FieldType = FieldType.Line,
                PrintType = PrintType.Static,
                TextAreaWidth = 1,
                TextAreaHeight = 300
            };
        }

        public static FieldModel CreateANewSplitter_H(Guid modelId)
        {
            return new FieldModel()
            {
                ModelID = modelId,
                FieldID = Guid.NewGuid(),
                FieldName = "横线",
                BindingText = "",
                Enable = true,
                FontFamilyName = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontFamilyName,
                FontSize = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontSize,
                FieldType = FieldType.Line,
                PrintType = PrintType.Static,
                TextAreaWidth = 300,
                TextAreaHeight = 1
            };
        }

        public static FieldModel CreateANewDataBlock(Guid modelId, string dataBlockTemplateName,
            string fontFamilyName,decimal fontSize,int textAreaWidth,int textAreaHeight)
        {
            return new FieldModel()
            {
                ModelID = modelId,
                FieldID = Guid.NewGuid(),
                FieldName = dataBlockTemplateName,
                BindingText = dataBlockTemplateName,
                Enable = true,
                FontFamilyName = fontFamilyName,
                FontSize = fontSize,
                FieldType = FieldType.DataBlock,
                PrintType = PrintType.Dynamic,
                TextAreaWidth = textAreaWidth,
                TextAreaHeight = textAreaHeight
            };
        }

        public static FieldModel CreateANewField(Guid modelId)
        {
            return new FieldModel()
            {
                ModelID = modelId,
                FieldID = Guid.NewGuid(),
                FieldName = "",
                BindingText = "",
                Enable = true,
                FontFamilyName = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontFamilyName,
                FontSize = PaintManager.CurrentView.CurrentProperty.CurrentFieldModel.FontSize,
                FieldType = FieldType.String
            };
        }
        public FieldModel Copy(Guid modelID)
        {
            return new FieldModel()
            {
                ModelID = modelID,
                FieldID = Guid.NewGuid(),
                FieldName = this.FieldName,
                BindingText = this.BindingText,
                Enable = this.Enable,
                FontFamilyName = this.FontFamilyName,
                FontSize = this.FontSize,
                LocationX = this.LocationX,
                LocationY = this.LocationY,
                FieldType = this.FieldType,
                PrintType = this.PrintType,
                TextAreaWidth = this.TextAreaWidth,
                TextAreaHeight = this.TextAreaHeight,
                Bold = this.Bold,
                Italic = this.Italic
            };
        }

        public void SyncField(FieldModel fmSync)
        {
            this.FieldName = fmSync.FieldName;
            this.BindingText = fmSync.BindingText;
            this.Enable = fmSync.Enable;
            this.FontFamilyName = fmSync.FontFamilyName;
            this.FontSize = fmSync.FontSize;
            this.LocationX = fmSync.LocationX;
            this.LocationY = fmSync.LocationY;
            this.FieldType = fmSync.FieldType;
            this.PrintType = fmSync.PrintType;
            this.TextAreaWidth = fmSync.TextAreaWidth;
            this.TextAreaHeight = fmSync.TextAreaHeight;
            this.Bold = fmSync.Bold;
            this.Italic = fmSync.Italic;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            FieldModel fm = obj as FieldModel;
            if (fm.ModelID == this.ModelID
                && fm.FieldID == this.FieldID
                && fm.FieldName == this.FieldName
                && fm.BindingText == this.BindingText
                && fm.Enable == this.Enable
                && fm.FontFamilyName == this.FontFamilyName
                && fm.FontSize == this.FontSize
                && fm.LocationX == this.LocationX
                && fm.LocationY == this.LocationY
                && fm.FieldType == this.FieldType
                && fm.PrintType == this.PrintType
                && fm.TextAreaHeight == this.TextAreaHeight
                && fm.TextAreaWidth == this.TextAreaWidth
                && fm.Bold == this.Bold
                && fm.Italic == this.Italic)
                return true;
            else
                return false;
        }
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
