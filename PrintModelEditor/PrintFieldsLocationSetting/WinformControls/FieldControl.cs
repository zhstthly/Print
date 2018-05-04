using PrintFieldsLocationSetting.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PrintFieldsLocationSetting
{
    public partial class FieldControl : DrawingControlBase
    {
        bool loading = false;
        //提示框
        //ToolTip tt = new ToolTip();
        //文本框头的高度
        int headerHeight = 21;
        //文本框是否是编辑状态
        bool editing = true;
        //鼠标按下位置
        protected Point MouseDownPosition { get; set; }

        #region 纸张缩放比
        public override decimal SizePercentNow
        {
            get
            {
                return base.SizePercentNow;
            }
            set
            {
                base.SizePercentNow = value;
                if (SizePercentNow > 0)
                    ChangeBindingTextFont();
            }
        }
        #endregion

        #region 模板属性
        #region 文本字体名
        public override string InitFontFamilyName
        {
            set
            {
                base.InitFontFamilyName = value;
                ChangeBindingTextFont();
            }
        }
        #endregion

        #region 文本字体大小
        public override float InitFontSize
        {
            set
            {
                base.InitFontSize = value;
                ChangeBindingTextFont();
            }
        }
        #endregion

        public override bool Bold
        {
            set
            {
                base.Bold = value;
                ChangeBindingTextFont();
            }
        }

        public override bool Italic
        {
            set
            {
                base.Italic = value;
                ChangeBindingTextFont();
            }
        }

        #region 字段区域宽度
        public override int TextAreaWidth
        {
            set
            {
                base.TextAreaWidth = value;
                ChangeBindingTextFont();
            }
        }
        #endregion

        #region 字段区域高度
        public override int TextAreaHeight
        {
            set
            {
                base.TextAreaHeight = value;
                ChangeBindingTextFont();
            }
        }
        #endregion

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
                        else if (AdjustP.X + FontIn100Percent.Width > PaintManager.CurrentView.FixedPageSize.Width - PaintManager.CurrentView.Padding)
                            AdjustP.X = PaintManager.CurrentView.FixedPageSize.Width - FontIn100Percent.Width - PaintManager.CurrentView.Padding;
                        if (AdjustP.Y < PaintManager.CurrentView.Padding)
                            AdjustP.Y = PaintManager.CurrentView.Padding;
                        else if (AdjustP.Y + FontIn100Percent.Height > PaintManager.CurrentView.FixedPageSize.Height - PaintManager.CurrentView.Padding)
                            AdjustP.Y = PaintManager.CurrentView.FixedPageSize.Height - FontIn100Percent.Height - PaintManager.CurrentView.Padding;
                    }
                    if (this.Visible != CurrentField.Enable)
                        this.Visible = CurrentField.Enable;
                    base.FixedLocationInPage = AdjustP;
                    //修改文本框坐标
                    Point controlInView = PaintConvert.PageToView(PaintManager.CurrentView.PageLocation,
                                            AdjustP.MultiplyPercentage(SizePercentNow));
                    this.Location = new Point(controlInView.X, controlInView.Y).AddOffset(new Point(0, -pn_Header.Height));
                    if (CurrentField.FieldType == FieldType.BarCode || CurrentField.FieldType == FieldType.Image 
                        ||(PaintManager.CurrentView.PaddingEnable
                        && CurrentField.TextAreaWidth != 0 && CurrentField.TextAreaHeight != 0))
                        lb_ShowText.BorderStyle = BorderStyle.FixedSingle;
                    else
                        lb_ShowText.BorderStyle = BorderStyle.None;
                    PaintManager.CurrentDataManager.SyncField(CurrentField);
                }
            }
        }
        #endregion
        #endregion

        #region 文本字体在100%时的尺寸
        Size FontIn100Percent
        {
            get
            {
                lb_ShowText.Font = new Font(new FontFamily(CurrentField.FontFamilyName), (float)CurrentField.FontSize);
                return lb_ShowText.Size;
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
                    lb_ShowText.Focus();
                    lb_ShowText.BackColor = Color.LightPink;
                }
                else
                {
                    if (Editing)
                        Editing = false;
                    lb_ShowText.BackColor = Color.White;
                }
                ChangeTbSize();
            }
        }
        #endregion

        #region 编辑状态
        public bool Editing
        {
            get { return editing; }
            set
            {
                editing = value;
                if (value)
                {
                    pn_Header.Height = headerHeight;
                    tb_BindingText.Visible = true;
                    lb_ShowText.Location = tb_BindingText.Location;
                }
                else
                {
                    if(string.IsNullOrEmpty(CurrentField.FieldName.Trim()))
                        PaintManager.CurrentDataManager.DeleteField(this);
                    pn_Header.Height = 0;
                    tb_BindingText.Visible = false;
                    lb_ShowText.Location = new Point(0, 0);
                    if (string.IsNullOrEmpty(CurrentField.BindingText))
                        tb_BindingText.Text = cb_FieldName.Text;
                }
                FixedLocationInPage = FixedLocationInPage;
                ChangeTbSize();
            }
        }
        #endregion

        public void ChangeBindingTextFont()
        {
            if (CurrentField.FontSize * SizePercentNow == 0 || string.IsNullOrEmpty(CurrentField.FontFamilyName))
                return;
            FontStyle fs = (CurrentField.Bold ? FontStyle.Bold : FontStyle.Regular)| 
                (CurrentField.Italic ? FontStyle.Italic : FontStyle.Regular);
            tb_BindingText.Font = new Font(new FontFamily(CurrentField.FontFamilyName),
                (float)(CurrentField.FontSize * SizePercentNow), fs);
             if(SizePercentNow == 0 || string.IsNullOrEmpty(CurrentField.BindingText))
                return;
            FixedLocationInPage = FixedLocationInPage;
            ChangeSizeToAdaptFont();
        }

        public FieldControl(FieldModel fm, bool editing)
        {
            InitializeComponent();
            //初始化操作
            CurrentField = fm;
            this.Enable = fm.Enable;
            Editing = editing;
        }

        //修改文本框大小
        void ChangeTbSize()
        {
            if (Editing)
            {
                if (CurrentField.TextAreaWidth == 0 || CurrentField.TextAreaHeight == 0)
                {
                    lb_ShowText.AutoSize = true;
                    tb_BindingText.Size = new Size(Math.Max(pn_Header.Width, tb_BindingText.Width), lb_ShowText.Height + 6);
                    this.Width = tb_BindingText.Width;
                    this.Height = pn_Header.Height + 2 + tb_BindingText.Height;
                }
                else
                {
                    lb_ShowText.AutoSize = false;
                    lb_ShowText.Width = CurrentField.TextAreaWidth;
                    lb_ShowText.Height = CurrentField.TextAreaHeight;
                    tb_BindingText.Size = new Size(CurrentField.TextAreaWidth, CurrentField.TextAreaHeight);
                    this.Width = Math.Max(tb_BindingText.Width,pn_Header.Width);
                    this.Height = pn_Header.Height + 2 + tb_BindingText.Height;
                }
            }
            else
            {
                if (CurrentField.TextAreaWidth == 0 || CurrentField.TextAreaHeight == 0)
                {
                    lb_ShowText.AutoSize = true;
                }
                else
                {
                    lb_ShowText.AutoSize = false;
                    lb_ShowText.Width = CurrentField.TextAreaWidth;
                    lb_ShowText.Height = CurrentField.TextAreaHeight;
                }
                this.Size = lb_ShowText.Size;
            }
        }

        //文本框大小适应字体大小
        void ChangeSizeToAdaptFont()
        {

            string textStr = CurrentField.BindingText.EndsWith("\r\n") ? CurrentField.BindingText + " " : CurrentField.BindingText;
            lb_ShowText.Text = textStr;
            lb_ShowText.Font = tb_BindingText.Font;
            ChangeTbSize();
        }

        private void tb_BindingText_TextChanged(object sender, EventArgs e)
        {
            CurrentField.BindingText = tb_BindingText.Text;
            ChangeSizeToAdaptFont();
        }

        private void tb_FieldName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tb_BindingText.Focus();
        }

        public void FocusName()
        {
            this.cb_FieldName.Focus();
        }

        private void MoveControl(Point moveP)
        {
            FixedLocationInPage = FixedLocationInPage.AddOffset(moveP);
        }

        private void lb_FieldName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MoveControl(new Point(0, -moveDistance));
                    break;
                case Keys.Down:
                    MoveControl(new Point(0, +moveDistance));
                    break;
                case Keys.Left:
                    MoveControl(new Point(-moveDistance, 0));
                    break;
                case Keys.Right:
                    MoveControl(new Point(moveDistance, 0));
                    break;
                case Keys.Delete:
                    PaintManager.CurrentDataManager.DeleteField(this);
                    break;
            }
            e.IsInputKey = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.ActiveControl.Name == lb_ShowText.Name
                || this.ActiveControl.Name == lb_FieldName.Name)
            {
                switch (keyData)
                {
                    case Keys.Up:
                        return true;//不继续处理
                    case Keys.Down:
                        return true;
                    case Keys.Left:
                        return true;
                    case Keys.Right:
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lb_FieldName_Click(object sender, EventArgs e)
        {
            lb_FieldName.Focus();
        }

        private void lb_ShowText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Editing)
                Editing = true;
        }

        private void lb_ShowText_MouseDown(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left)
            {
                MouseDownPosition = e.Location;
            }
            if (!this.Selected)
            {
                Selected = true;
            }
        }

        private void lb_ShowText_MouseMove(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control && MouseButtons == MouseButtons.Left &&
                this.Location !=
                PaintManager.CurrentView.PointToClient(MousePosition.AddOffset(new Point(-MouseDownPosition.X, -MouseDownPosition.Y))))
            {
                this.Location = PaintManager.CurrentView.PointToClient(MousePosition.AddOffset(new Point(-MouseDownPosition.X, -MouseDownPosition.Y)));
            }
        }

        private void lb_ShowText_MouseUp(object sender, MouseEventArgs e)
        {
            FixedLocationInView = new Point(this.Location.X, this.Location.Y + pn_Header.Height);
        }

        private void FieldControl_Load(object sender, EventArgs e)
        {
            loading = true;
            DataTable dt = new DataTable();
            dt.Columns.Add("value",typeof(int));
            dt.Columns.Add("display", typeof(string));
            if (this.CurrentField.FieldType == FieldType.Image)
            {
                foreach (var item in PrintDatas.pictureLocationMList.OrderBy(b => b.LocationName))
                {
                    dt.Rows.Add(0, item.LocationName);
                }
            }
            else
            {
                foreach (var item in PrintDatas.PrintFieldBM.OrderBy(b => b.Description).OrderBy(b => b.PrintName))
                {
                    dt.Rows.Add(item.ID, item.PrintName);
                }
            }
            //cb_FieldName.DrawItem += Cb_FieldName_DrawItem;
            //cb_FieldName.DropDownClosed += Cb_FieldName_DropDownClosed;
            cb_FieldName.DataSource = dt;
            cb_FieldName.DisplayMember = "display";
            cb_FieldName.ValueMember = "value";
            loading = false;  
            //tt.SetToolTip(cb_FieldName,"");
            cb_FieldName.Text = CurrentField.FieldName;
            tb_BindingText.Text = CurrentField.BindingText;
        }

        //private void Cb_FieldName_DropDownClosed(object sender, EventArgs e)
        //{
        //    tt.Hide(cb_FieldName);
        //}

        //private void Cb_FieldName_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    // 绘制背景
        //    e.DrawBackground();
        //    //绘制列表项目
        //    e.Graphics.DrawString(PrintDatas.PrintFieldBM[e.Index].PrintName, e.Font, Brushes.Black, e.Bounds);
        //    //将高亮的列表项目的文字传递到toolTip1(之前建立ToolTip的一个实例)
        //    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        //        tt.Show(PrintDatas.PrintFieldBM[e.Index].Description, cb_FieldName, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
        //    e.DrawFocusRectangle();
        //}

        private void cb_FieldName_TextChanged(object sender, EventArgs e)
        {
            if (loading)
                return;
            CurrentField.FieldName = cb_FieldName.Text;
        }

        private void cb_FieldName_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cb_FieldName.Text))
            {
                this.Selected = false;
            }
        }
    }
}
