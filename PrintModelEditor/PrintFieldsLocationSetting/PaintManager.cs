using PrintFieldsLocationSetting.Models;
using PrintFieldsLocationSetting.WinformControls;
using System;
using System.Drawing;

namespace PrintFieldsLocationSetting
{
    public class PaintManager
    {
        public delegate void PageSizePercentChangedHandle(int percentage);
        public static event PageSizePercentChangedHandle PageSizePercentChangedEvent;

        public delegate void FieldControlLocationChangedHandle(Point location);
        public static event FieldControlLocationChangedHandle FieldControlLocationChangedEvent;
        public static PaintView CurrentView { get; set; }
        public static DataManager CurrentDataManager { get; set; }
        public static Fm_DataModel fm_DataModel = Fm_DataModel.FormDataModel;
        public static Guid CopyModelId { get; set; }
        private static decimal sizePercentNow = 1;
        const decimal changePercent = 0.05m;
        public static decimal SizePercentNow
        {
            get { return sizePercentNow; }
            set
            {
                sizePercentNow = value;
                if (sizePercentNow > 2)
                    sizePercentNow = 2;
                else if(sizePercentNow < 0)
                    sizePercentNow = 0;
                int pecentNow = (int)(SizePercentNow * 100);
                PageSizePercentChangedEvent(pecentNow);
                CurrentView.SizePercentNow = SizePercentNow;
            }
        }

        public static void FieldControlLocationChanged(Point location)
        {
            FieldControlLocationChangedEvent(location);
        }

        public static int Millimeter2Pix(decimal unitOfMm)
        {
            return PaintConvert.Millimeter2Pix(unitOfMm);
        }

        public static void ChangeEnable(bool value)
        {
            CurrentView.PaddingEnable = value;
        }

        public static void ChangeUnSplitBlockHeight(int height)
        {
            CurrentView.UnSplitBlockHeight = height;
        }

        public static void ChangeBlankHeight(int height)
        {
            CurrentView.BlankHeight = height;
        }

        public static void SetPaddingLine(int padding)
        {
            CurrentView.Padding = padding;
        }

        public static void Enlarge()
        {
            SizePercentNow = SizePercentNow + changePercent;
        }

        public static void Narrow()
        {
            SizePercentNow = SizePercentNow - changePercent;
        }

        public static void PageSizeSelectionChanged(PageModel selectedValue)
        {
            int pageWidth = 0;
            int pageHeight = 0;
            if (selectedValue != null)
            {
                pageWidth = Millimeter2Pix(selectedValue.Width);
                pageHeight = Millimeter2Pix(selectedValue.Height);
            }
            CurrentView.ResetPage(new Size(pageWidth, pageHeight));
        }

        public static DrawingControlBase AddANewControl(FieldModel fm)
        {
            return CurrentDataManager.FieldModelListAddingNew(fm);
        }
    }
}
