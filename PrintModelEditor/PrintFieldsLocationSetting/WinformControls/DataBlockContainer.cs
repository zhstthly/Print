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
    public partial class DataBlockContainer : DrawingControlBase
    {
        DataBlockTemplateModel CurrentTemplateModel { get; set; }
        List<DataBlockControl> currentDBList = new List<DataBlockControl>();

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
                    Point AdjustP = new Point(0,value.Y);
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
                    if (PaintManager.CurrentView.PaddingEnable
                        && CurrentField.TextAreaWidth != 0 && CurrentField.TextAreaHeight != 0)
                        this.pn_Area.BorderStyle = BorderStyle.FixedSingle;
                    else
                        this.pn_Area.BorderStyle = BorderStyle.None;
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
                pn_Area.Height = value;
                ResetArea();
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
                    foreach (var dc in currentDBList)
                    {
                        dc.BackColor = Color.LightPink;
                    }
                }
                else
                {
                    foreach (var dc in currentDBList)
                    {
                        dc.Selected = false;
                    }
                }
            }
        }
        #endregion

        public void AddDataControls(DataBlockTemplateModel templateModel)
        {
            ResetArea();
            int width = this.pn_Area.Width / templateModel.ColumnNum;
            for (int i = 0; i < templateModel.ColumnNum; i++)
            {
                DataBlockModel newDataBlockModel = PrintDatas.dataBlockMList.Find(m => m.TemplateModelID == templateModel.ModelID
                                                                                    && m.Index == i);
                DataBlockControl dc = new DataBlockControl(1, newDataBlockModel,true);
                dc.Dock = DockStyle.Left;
                dc.DataSelectedEvent += Dc_DataSelectedEvent;
                dc.DataKeyDownEvent += Dc_DataKeyDownEvent;
                currentDBList.Add(dc);
                this.pn_Area.Controls.Add(dc);
                dc.BringToFront();
            }
            currentDBList[currentDBList.Count - 1].Dock = DockStyle.Fill;
            foreach (var dc in currentDBList)
            {
                dc.FontFamilyName = templateModel.FontFamilyName;
                dc.FontSize = templateModel.FontSize;
                dc.Distance = templateModel.Distance;
                dc.LineWidth = templateModel.LineWidth;
            }
        }

        private void Dc_DataKeyDownEvent(PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                FixedLocationInPage = new Point(FixedLocationInPage.X, FixedLocationInPage.Y - 1);
            }
            else if(e.KeyCode == Keys.Down)
            {
                FixedLocationInPage = new Point(FixedLocationInPage.X, FixedLocationInPage.Y + 1);
            }
        }

        private void Dc_DataSelectedEvent(object sender)
        {
            this.Selected = true;
        }

        void ResetArea()
        {
            pn_Area.Width = (int)((CurrentTemplateModel.PageWidth - CurrentTemplateModel.PaddingLeft - CurrentTemplateModel.PaddingRight) * 1);
            this.Height = (int)((pn_Area.Height + CurrentTemplateModel.PaddingTop + CurrentTemplateModel.PaddingBottom) * 1);
            pn_Area.Location = new Point((int)(CurrentTemplateModel.PaddingLeft * 1), (int)(CurrentTemplateModel.PaddingTop * 1));
        }

        public DataBlockContainer(FieldModel fm)
        {
            InitializeComponent();
            //初始化操作
            CurrentField = fm;
            CurrentTemplateModel = PrintDatas.dataBlockTMList.Find(t => t.ModelName == fm.FieldName
                && t.PageWidth == PaintManager.CurrentView.FixedPageSize.Width);
            AddDataControls(CurrentTemplateModel);
            this.Enable = fm.Enable;
            TextAreaWidth = fm.TextAreaWidth;
            TextAreaHeight = fm.TextAreaHeight;
        }
    }
}
