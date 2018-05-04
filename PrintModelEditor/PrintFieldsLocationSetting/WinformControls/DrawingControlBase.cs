using PrintFieldsLocationSetting.Models;
using System.Drawing;
using System.Windows.Forms;

namespace PrintFieldsLocationSetting
{
    public class DrawingControlBase : UserControl
    {
        public delegate void DrawingControlBaseSelectedHandle(object sender);
        public event DrawingControlBaseSelectedHandle DrawingControlBaseSelectedEvent;
        public static DrawingControlBase Current { get; set; }
        public FieldModel CurrentField { get; protected set; }
        protected decimal sizePercentNow;
        bool selected;
        //每次方向键移动量
        protected int moveDistance = 1;

        #region 模板属性
        #region 文本字体名
        public virtual string InitFontFamilyName
        {
            set
            {
                CurrentField.FontFamilyName = value;
            }
        }
        #endregion

        #region 文本字体大小
        public virtual float InitFontSize
        {
            set
            {
                CurrentField.FontSize = (decimal)value;
            }
        }
        #endregion

        #region 字段加粗
        public virtual bool Bold
        {
            set
            {
                CurrentField.Bold = value;
            }
        }
        #endregion

        #region 字段倾斜
        public virtual bool Italic
        {
            set
            {
                CurrentField.Italic = value;
            }
        }
        #endregion

        #region 字段类型(文字，图片...)
        public FieldType FieldType
        {
            set
            {
                CurrentField.FieldType = value;
                PaintManager.CurrentDataManager.SyncField(CurrentField);
            }
        }
        #endregion

        #region 打印类型（静态文本，动态数据...）
        public PrintType PrintType
        {
            set
            {
                CurrentField.PrintType = value;
                PaintManager.CurrentDataManager.SyncField(CurrentField);
            }
        }
        #endregion

        #region 字段区域宽度
        public virtual int TextAreaWidth
        {
            set
            {
                CurrentField.TextAreaWidth = value;
            }
        }
        #endregion

        #region 字段区域高度
        public virtual int TextAreaHeight
        {
            set
            {
                CurrentField.TextAreaHeight = value;
            }
        }
        #endregion

        #region 有效性
        public bool Enable
        {
            set
            {
                CurrentField.Enable = value;
                this.Visible = value;
            }
        }
        #endregion

        #region 在纸张上的固定位置
        public virtual Point FixedLocationInPage
        {
            get
            {
                return new Point(CurrentField.LocationX, CurrentField.LocationY);
            }
            set
            {
                CurrentField.LocationX = value.X;
                CurrentField.LocationY = value.Y;
                if (Selected)
                    PaintManager.CurrentView.CurrentProperty.CurrentFieldModel = CurrentField;
            }
        }
        #endregion
        #endregion

        #region 文本框在视图上的坐标
        public Point FixedLocationInView
        {
            set
            {
                Point pInPage = PaintConvert.ViewToPage(PaintManager.CurrentView.PageLocation, value);
                FixedLocationInPage = pInPage.DividePercentage(SizePercentNow);
            }
        }
        #endregion

        #region 纸张缩放比
        public virtual decimal SizePercentNow
        {
            get { return sizePercentNow; }
            set
            {
                sizePercentNow = value;
            }
        }
        #endregion

        #region 选中状态
        public virtual bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (value)
                {
                    Current = this;
                    DrawingControlBaseSelectedEvent(this);
                    this.BringToFront();
                    PaintManager.CurrentView.SetControlsZIndex();
                    PaintManager.CurrentView.CurrentProperty.CurrentFieldModel = CurrentField;
                }
                else
                {
                    if (Current == this)
                    {
                        Current = null;
                    }
                }
            }
        }
        #endregion

        public void RemoveThis()
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        public DrawingControlBase()
        {
            CurrentField = new FieldModel();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DrawingControlBase
            // 
            this.Name = "DrawingControlBase";
            this.Size = new System.Drawing.Size(162, 94);
            this.ResumeLayout(false);
        }
    }
}
