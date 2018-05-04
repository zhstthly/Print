using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrintFieldsLocationSetting.Models;

namespace PrintFieldsLocationSetting.WinformControls
{
    public partial class SplitterControl : DrawingControlBase
    {
        #region 在纸张上的固定位置
        public override Point FixedLocationInPage
        {
            get { return base.FixedLocationInPage; }
            set
            {
                if (PaintManager.CurrentView.FixedPageSize == new Size(0, 0))
                {
                    this.Visible = false;
                }
                else
                {
                    this.Visible = true;
                    Point AdjustP = value;
                    //根据padding调整坐标
                    if (PaintManager.CurrentView.PaddingEnable)
                    {
                        if (AdjustP.X < PaintManager.CurrentView.Padding)
                            AdjustP.X = PaintManager.CurrentView.Padding;
                        if (AdjustP.Y < PaintManager.CurrentView.Padding)
                            AdjustP.Y = PaintManager.CurrentView.Padding;
                    }
                    if (this.Visible != CurrentField.Enable)
                        this.Visible = CurrentField.Enable;
                    base.FixedLocationInPage = AdjustP;
                    //修改文本框坐标
                    Point controlInView = PaintConvert.PageToView(PaintManager.CurrentView.PageLocation,
                                            AdjustP.MultiplyPercentage(SizePercentNow));
                    this.Location = new Point(controlInView.X, controlInView.Y);
                    PaintManager.CurrentDataManager.SyncField(CurrentField);
                }
            }
        }
        #endregion

        #region 数据块宽度
        public override int TextAreaWidth
        {
            set
            {
                base.TextAreaWidth = value;
                this.Width = value;

            }
        }
        #endregion

        #region 数据块高度
        public override int TextAreaHeight
        {
            set
            {
                base.TextAreaHeight = value;
                this.Height = value;
            }
        }
        #endregion

        #region 选中状态
        public override bool Selected
        {
            get { return base.Selected; }
            set
            {
                base.Selected = value;
                if (value)
                {
                    this.BackColor = Color.LightPink;
                }
                else
                {
                    this.BackColor = Color.Black;
                }
            }
        }
        #endregion

        public SplitterControl(FieldModel fm)
        {
            InitializeComponent();
            //初始化操作
            CurrentField = fm;
            this.Enable = fm.Enable;
            TextAreaWidth = fm.TextAreaWidth;
            TextAreaHeight = fm.TextAreaHeight;
        }

        private void SplitterControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                FixedLocationInPage = new Point(FixedLocationInPage.X, FixedLocationInPage.Y - 1);
            }
            else if (e.KeyCode == Keys.Down)
            {
                FixedLocationInPage = new Point(FixedLocationInPage.X, FixedLocationInPage.Y + 1);
            }
        }

        private void SplitterControl_MouseClick(object sender, MouseEventArgs e)
        {
            this.Selected = true;
        }
    }

    public enum Direction
    {
        Horizontal,
        Vertical
    }
}
