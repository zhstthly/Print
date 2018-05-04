using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PrintFieldsLocationSetting.Models;
using System.ComponentModel;
using PrintFieldsLocationSetting.WinformControls;
using System.Linq;

namespace PrintFieldsLocationSetting
{
    public partial class PaintView : UserControl
    {
        List<GuideLine> guides = new List<GuideLine>();
        List<DrawingControlBase> fields = new List<DrawingControlBase>();
        //页面坐标(前)
        Point oldPageLocation { get; set; }
        Size fixedPageSize;
        Point fixedPageLocation;
        Point offsetPage = new Point(0, 0);
        decimal sizePercentNow;
        int padding;
        int scrollMoveDistance = 10;
        public FieldProperty CurrentProperty { get; set; }
        bool paddingEnable;
        public bool PaddingEnable
        {
            get { return paddingEnable; }
            set
            {
                paddingEnable = value;
                Padding = Padding;
            }
        }

        public int UnSplitBlockHeight
        {
            set
            {
                pn_UnSplitBlock.Height = value;
            }
        }

        public int BlankHeight
        {
            set
            {
                pn_Blank.Height = value;
            }
        }

        new public int Padding
        {
            get { return padding; }
            set
            {
                padding = value;
                //添加页边距线
                foreach (GuideLine g in guides)
                {
                    g.Padding = value;
                }
                if (paddingEnable)
                {
                    foreach (DrawingControlBase dcb in this.fields)
                    {
                        dcb.FixedLocationInPage = dcb.FixedLocationInPage;
                    }
                    SetControlsZIndex();
                }
            }
        }
        public Point PageLocation
        {
            get { return pn_Page.Location; }
        } 
        //页面缩放比
        public decimal SizePercentNow
        {
            get { return sizePercentNow; }
            set
            {
                sizePercentNow = value;
                //缩放纸张大小
                FixedPageSize = FixedPageSize;
            }
        }

        //页面固定大小(100%时)
        public Size FixedPageSize
        {
            get { return fixedPageSize; }
            set
            {
                fixedPageSize = value;
                pn_Page.Size = new Size((int)(FixedPageSize.Width * SizePercentNow),
                    (int)(FixedPageSize.Height * SizePercentNow));
                FixedPageLocation = FixedPageLocation;
            }
        }

        //页面固定位置
        public Point FixedPageLocation
        {
            get { return fixedPageLocation; }
            set
            {
                Point viewCenter = new Point(this.Width / 2, this.Height / 2);
                Point pageCenter = new Point(pn_Page.Width / 2, pn_Page.Height / 2);
                fixedPageLocation = new Point(viewCenter.X - pageCenter.X, viewCenter.Y - pageCenter.Y);
                pn_Page.Location = new Point(fixedPageLocation.X+ OffsetPage.X, fixedPageLocation.Y + OffsetPage.Y);
                foreach (DrawingControlBase dc in fields)
                {
                    dc.FixedLocationInPage = dc.FixedLocationInPage;
                }
                foreach (DrawingControlBase dc in guides)
                {
                    dc.FixedLocationInPage = dc.FixedLocationInPage;
                }
                SetControlsZIndex();
                //修改滚动条
                ResetScrollBar();
                Resetfp_FieldProperty();
            }
        }

        void Resetfp_FieldProperty()
        {
            fp_FieldProperty.Location = new Point(this.Width - fp_FieldProperty.Width - v_ScrollBar.Width, 0);
            fp_FieldProperty.BringToFront();
        }

        void ResetScrollBar()
        {
            if (SizePercentNow == 0)
                return;
            int d_width = (int)((pn_Page.Width - Math.Min(this.Width, pn_Page.Width)) / SizePercentNow / 2);
            int h_maximun = Math.Max(d_width, Math.Abs((int)OffsetPage.X));
            h_ScrollBar.Maximum = h_maximun;
            h_ScrollBar.Minimum = -h_maximun;
            int d_height = (int)((pn_Page.Height - Math.Min(this.Height, pn_Page.Size.Height)) / SizePercentNow / 2);
            int v_maximun = Math.Max(d_height, Math.Abs((int)OffsetPage.Y));
            v_ScrollBar.Maximum = v_maximun;
            v_ScrollBar.Minimum = -v_maximun;
        }

        public void SetControlsZIndex()
        {
            foreach (GuideLine gl in guides)
            {
                gl.HideWhenInScrollBar();
            }
            pn_HScroll.BringToFront();
            v_ScrollBar.BringToFront();
            if(PaintManager.CurrentView != null)
                PaintManager.CurrentView.CurrentProperty.BringToFront();
        }

        //页面偏移量
        public Point OffsetPage
        {
            get { return offsetPage; }
            set
            {
                offsetPage = value;
                FixedPageLocation = FixedPageLocation;
            }
        }

        public void ResetPage(Size pageSize)
        {
            FixedPageSize = pageSize;
        }

        public void AddGuideLines()
        {
            guides.Add(new GuideLine(GuideDirection.Left));
            guides.Add(new GuideLine(GuideDirection.Top));
            guides.Add(new GuideLine(GuideDirection.Right));
            guides.Add(new GuideLine(GuideDirection.Bottom));
            foreach(GuideLine gl in guides)
            {
                this.Controls.Add(gl);
            }
        }

        public PaintView()
        {
            InitializeComponent();
            CurrentProperty = this.fp_FieldProperty;
            this.MouseWheel += PaintView_MouseWheel;
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private void PaintView_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (ModifierKeys == Keys.Control)
            //{
            //    if (e.Delta > 0)
            //        PaintManager.Enlarge();
            //    else
            //        PaintManager.Narrow();
            //}
            if (ModifierKeys == Keys.Shift)
            {
                if (e.Delta > 0)
                {
                    if (h_ScrollBar.Value - scrollMoveDistance < h_ScrollBar.Minimum)
                        h_ScrollBar.Minimum = h_ScrollBar.Value - scrollMoveDistance;
                    h_ScrollBar.Value = h_ScrollBar.Value - scrollMoveDistance;
                }
                else
                {
                    if (h_ScrollBar.Value + scrollMoveDistance > h_ScrollBar.Maximum)
                        h_ScrollBar.Maximum = h_ScrollBar.Value + scrollMoveDistance;
                    h_ScrollBar.Value = h_ScrollBar.Value + scrollMoveDistance;
                }
            }
            else
            {
                if (e.Delta > 0)
                {
                    if (v_ScrollBar.Value - scrollMoveDistance < v_ScrollBar.Minimum)
                        v_ScrollBar.Minimum = v_ScrollBar.Value - scrollMoveDistance;
                    v_ScrollBar.Value = v_ScrollBar.Value - scrollMoveDistance;
                }
                else
                {
                    if (v_ScrollBar.Value + scrollMoveDistance > v_ScrollBar.Maximum)
                        v_ScrollBar.Maximum = v_ScrollBar.Value + scrollMoveDistance;
                    v_ScrollBar.Value = v_ScrollBar.Value + scrollMoveDistance;
                }
            }
        }

        private void Fc_FieldControlClickEvent(object sender)
        {
            int count = this.fields.Count;
            for (int i = 0; i < this.fields.Count;)
            {
                if (this.fields[i] != ((DrawingControlBase)sender))
                    this.fields[i].Selected = false;
                i += 1 + this.fields.Count - count;
            }
            PaintManager.CurrentDataManager.SelectByID(((DrawingControlBase)sender).CurrentField.FieldID);
        }

        public void UnSelectAll()
        {
            int controlsCount = this.fields.Count;
            for (int i = 0; i < controlsCount; i++)
            {
                this.fields[i].Selected = false;
                i -= controlsCount - this.fields.Count;
                controlsCount = this.fields.Count;
            }
            PaintManager.CurrentDataManager.SelectNone();
        }

        private void Blank_Click(object sender, EventArgs e)
        {
            UnSelectAll();
        }

        public void SelectFieldControlByID(Guid id)
        {
            foreach (DrawingControlBase dcb in this.fields)
            {
                if (dcb.CurrentField.FieldID == id)
                {
                    dcb.Selected = true;
                }
            }
        }

        public void ClearFieldControl()
        {
            for (int i = 0;i< this.fields.Count;)
            {
                this.fields[i].RemoveThis();
                this.fields.Remove(this.fields[i]);
            }
        }

        public void SetEnableFieldControlByID(Guid id, bool enable)
        {
            foreach (DrawingControlBase dcb in this.fields)
            {
                if (dcb.CurrentField.FieldID == id)
                    dcb.Enable = enable;
            }
        }

        public void RemoveFieldControlByControl(DrawingControlBase dcb)
        {
            fields.Remove(dcb);
            dcb.RemoveThis();
        }

        public SplitterControl CreateASplitter(FieldModel fm)
        {
            SplitterControl sc = new SplitterControl(fm);
            fields.Add(sc);
            sc.DrawingControlBaseSelectedEvent += Fc_FieldControlClickEvent;
            this.Controls.Add(sc);
            sc.SizePercentNow = SizePercentNow;
            sc.BringToFront();
            sc.FixedLocationInPage = sc.FixedLocationInPage;
            return sc;
        }

        public void CleanBackgroundImage()
        {
            pn_Page.BackgroundImage = null;
        }

        public DataBlockContainer CreateADataBlock(FieldModel fm)
        {
            DataBlockContainer dbc = new DataBlockContainer(fm);
            fields.Add(dbc);
            dbc.DrawingControlBaseSelectedEvent += Fc_FieldControlClickEvent;
            this.Controls.Add(dbc);
            dbc.SizePercentNow = SizePercentNow;
            dbc.BringToFront();
            dbc.FixedLocationInPage = dbc.FixedLocationInPage;
            return dbc;
        }

        public FieldControl CreateAField(FieldModel fm, bool editing)
        {
            FieldControl fc = new FieldControl(fm, editing);
            fields.Add(fc);
            fc.DrawingControlBaseSelectedEvent += Fc_FieldControlClickEvent;
            this.Controls.Add(fc);
            fc.SizePercentNow = SizePercentNow;
            fc.BringToFront();
            fc.FocusName();
            return fc;
        }

        private void PaintView_SizeChanged(object sender, EventArgs e)
        {
            FixedPageLocation = FixedPageLocation;
        }

        private void v_ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            OffsetPage = new Point(OffsetPage.X, -v_ScrollBar.Value);
        }

        private void h_ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            OffsetPage = new Point(h_ScrollBar.Value, OffsetPage.Y);
        }

        private void cmi_AddNewField_Click(object sender, EventArgs e)
        {
            Point p = this.PointToClient(new Point(cm_FieldManager.Left, cm_FieldManager.Top));
            DrawingControlBase fc = PaintManager.AddANewControl(FieldModel.CreateANewField(PaintManager.CurrentDataManager.ModelID));
            if(fc != null)
                fc.FixedLocationInView = p;
        }

        private void PaintView_Load(object sender, EventArgs e)
        {
            AddGuideLines();
        }

        private void PaintView_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = PaintConvert.ViewToPage(PaintManager.CurrentView.PageLocation, e.Location);
            PaintManager.FieldControlLocationChanged(new Point((int)(p.X / SizePercentNow), (int)(p.Y/SizePercentNow)));
        }

        private void pn_Page_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            PaintManager.FieldControlLocationChanged(new Point((int)(p.X / SizePercentNow), (int)(p.Y / SizePercentNow)));
        }

        private void cm_FieldManager_Opening(object sender, CancelEventArgs e)
        {
            tsmi_AddDataBlock.DropDownItems.Clear();
            foreach (var dbtm in PrintDatas.dataBlockTMList.Where(t => t.PageWidth == FixedPageSize.Width).ToArray())
            {
                ToolStripItem tsi = new ToolStripMenuItem(dbtm.ModelName);
                tsmi_AddDataBlock.DropDownItems.Add(tsi);
                tsi.Click += Tsi_Click;
            }
        }

        private void Tsi_Click(object sender, EventArgs e)
        {
            if (fields.Count(f => f.CurrentField.FieldType == FieldType.DataBlock) > 0)
            {
                MessageBox.Show("一个模板只能有一个数据块！");
                return;
            }
            ToolStripItem tsi = sender as ToolStripItem;
            Point p = this.PointToClient(new Point(cm_FieldManager.Left, cm_FieldManager.Top));
            string dataBlockTemplateName = tsi.Text;
            DataBlockTemplateModel dbtm = PrintDatas.dataBlockTMList.Find(t => t.ModelName == dataBlockTemplateName
                && t.PageWidth == PaintManager.CurrentView.FixedPageSize.Width);
            DrawingControlBase dcb = PaintManager.AddANewControl(FieldModel.CreateANewDataBlock(
                PaintManager.CurrentDataManager.ModelID, dbtm.ModelName, dbtm.FontFamilyName, 
                (decimal)dbtm.FontSize, PaintManager.CurrentView.FixedPageSize.Width,60));
            if (dcb != null)
                dcb.FixedLocationInView = p;
        }

        private void tsmi_Splitter_H_Click(object sender, EventArgs e)
        {
            Point p = this.PointToClient(new Point(cm_FieldManager.Left, cm_FieldManager.Top));
            DrawingControlBase dcb = PaintManager.AddANewControl(FieldModel.CreateANewSplitter_H(PaintManager.CurrentDataManager.ModelID));
            if (dcb != null)
                dcb.FixedLocationInView = p;
        }

        private void tsmi_Splitter_V_Click(object sender, EventArgs e)
        {
            Point p = this.PointToClient(new Point(cm_FieldManager.Left, cm_FieldManager.Top));
            DrawingControlBase dcb = PaintManager.AddANewControl(FieldModel.CreateANewSplitter_V(PaintManager.CurrentDataManager.ModelID));
            if (dcb != null)
                dcb.FixedLocationInView = p;
        }

        private void tsmi_Picture_Click(object sender, EventArgs e)
        {
            Point p = this.PointToClient(new Point(cm_FieldManager.Left, cm_FieldManager.Top));
            DrawingControlBase dcb = PaintManager.AddANewControl(FieldModel.CreateANewImage(PaintManager.CurrentDataManager.ModelID));
            if (dcb != null)
                dcb.FixedLocationInView = p;
        }

        private void tsmi_BarCode_Click(object sender, EventArgs e)
        {
            Point p = this.PointToClient(new Point(cm_FieldManager.Left, cm_FieldManager.Top));
            DrawingControlBase dcb = PaintManager.AddANewControl(FieldModel.CreateANewBarCode(PaintManager.CurrentDataManager.ModelID));
            if (dcb != null)
                dcb.FixedLocationInView = p;
        }

        private void tsmi_BackGroundImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.jpg)|*.jpg";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strFileName = ofd.FileName;
                //其他代码
                Image img = Image.FromFile(strFileName);
                pn_Page.BackgroundImage = img;
            }
        }
    }
}
