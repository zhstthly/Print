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
    public partial class DataBlockModelView : UserControl
    {
        decimal percentage;
        DataBlockTemplateModel currentTemplateModel = new DataBlockTemplateModel();
        public bool Edit { get; set; }
        List<DataBlockControl> dataControls = new List<DataBlockControl>();
        DataBlockTemplateModel CurrentTemplateModel
        {
            get { return currentTemplateModel; }
            set
            {
                currentTemplateModel = value;
            }
        }

        public DataBlockModelProperty CurrentProperty
        {
            get { return this.uc_DataModelProperty; }
        }

        public int PageWidth
        {
            get { return CurrentTemplateModel.PageWidth; }
            set
            {
                CurrentTemplateModel.PageWidth = value;
                pn_Page.Width = value;
                CenterToCenter();
            }
        }
        
        public decimal Percentage
        {
            get { return percentage; }
            set
            {
                percentage = 1;
            }
        }

        public int PaddingTop
        {
            get { return CurrentTemplateModel.PaddingTop; }
            set
            {
                CurrentTemplateModel.PaddingTop = value;
                ResetArea();
            }
        }
        public int PaddingBottom
        {
            get { return CurrentTemplateModel.PaddingBottom; }
            set
            {
                CurrentTemplateModel.PaddingBottom = value;
                ResetArea();
            }
        }

        public int PaddingLeft
        {
            get { return CurrentTemplateModel.PaddingLeft; }
            set
            {
                CurrentTemplateModel.PaddingLeft = value;
                ResetArea();
            }
        }

        public int PaddingRight
        {
            get { return CurrentTemplateModel.PaddingRight; }
            set
            {
                CurrentTemplateModel.PaddingRight = value;
                ResetArea();
            }
        }

        public int LineWidth
        {
            get { return CurrentTemplateModel.LineWidth; }
            set
            {
                CurrentTemplateModel.LineWidth = value;
                ResetArea();
                foreach (var dc in dataControls)
                {
                    dc.LineWidth = value;
                }
            }
        }

        public string FontFamilyName
        {
            get { return CurrentTemplateModel.FontFamilyName; }
            set
            {
                CurrentTemplateModel.FontFamilyName = value;
                foreach(var dc in dataControls)
                {
                    dc.FontFamilyName = value;
                }
            }
        }

        public float FontSize
        {
            get { return CurrentTemplateModel.FontSize; }
            set
            {
                CurrentTemplateModel.FontSize = value;
                foreach (var dc in dataControls)
                {
                    dc.FontSize = value;
                }
            }
        }
        public int ColumnNum
        {
            get { return CurrentTemplateModel.ColumnNum; }
            set
            {
                CurrentTemplateModel.ColumnNum = value;
            }
        }
        public int Distance
        {
            get { return CurrentTemplateModel.Distance; }
            set
            {
                CurrentTemplateModel.Distance = value;
                foreach (var dc in dataControls)
                {
                    dc.Distance = value;
                }
            }
        }

        void ResetArea()
        {
            pn_Area.Width = (int)((PageWidth - PaddingLeft - PaddingRight) * Percentage);
            pn_Page.Height = (int)((pn_Area.Height + PaddingTop + PaddingBottom) * Percentage);
            pn_Area.Location = new Point((int)(PaddingLeft * Percentage), (int)(PaddingTop * Percentage));
        }

        public void CenterToCenter()
        {
            Point viewCenter = new Point(this.Width / 2, this.Height / 2);
            Point pageCenter = new Point(this.pn_Page.Width / 2, this.pn_Page.Height / 2);
            this.pn_Page.Location = new Point(viewCenter.X - pageCenter.X, viewCenter.Y - pageCenter.Y);
            this.uc_DataModelProperty.Location = new Point(this.Width - uc_DataModelProperty.Width, 0);
        }

        public DataBlockModelView()
        {
            InitializeComponent();
        }

        public void DeleteAllBlockControls(Guid templateModelID)
        {
            PrintDatas.dataBlockMList = PrintDatas.dataBlockMList.Where(m => m.TemplateModelID != templateModelID).ToList();
            RemoveAllDataBlockControls();
        }

        public void RemoveAllDataBlockControls()
        {
            for (int i = 0; i < dataControls.Count;)
            {
                this.pn_Area.Controls.Remove(dataControls[i]);
                dataControls[i].Dispose();
                dataControls.RemoveAt(i);
            }
        }

        public void AddDataControls(DataBlockTemplateModel templateModel)
        {
            CurrentTemplateModel = templateModel;
            RemoveAllDataBlockControls();
            PaddingLeft = templateModel.PaddingLeft;
            PaddingTop = templateModel.PaddingTop;
            PaddingRight = templateModel.PaddingRight;
            PaddingBottom = templateModel.PaddingBottom;
            ColumnNum = templateModel.ColumnNum;
            PageWidth = templateModel.PageWidth;
            int width = this.pn_Area.Width / ColumnNum;
            for (int i = 0; i < ColumnNum; i++)
            {
                DataBlockModel newDataBlockModel = PrintDatas.dataBlockMList.Find(m => m.TemplateModelID == templateModel.ModelID 
                                                                                    && m.Index == i);
                if (newDataBlockModel == null)
                {
                    newDataBlockModel = DataBlockModel.CreateNewInstance();
                    PrintDatas.dataBlockMList.Add(newDataBlockModel);
                    newDataBlockModel.ColumnWidth = (int)(width / Percentage);
                    newDataBlockModel.Index = i;
                    newDataBlockModel.TemplateModelID = templateModel.ModelID;
                }
                DataBlockControl dc = new DataBlockControl(Percentage, newDataBlockModel,false);
                dc.Dock = DockStyle.Left;
                dc.DataSelectedEvent += Dc_DataSelectedEvent;
                dataControls.Add(dc);
                this.pn_Area.Controls.Add(dc);
                dc.BringToFront();
            }
            dataControls[dataControls.Count - 1].Dock = DockStyle.Fill;
            FontFamilyName = templateModel.FontFamilyName;
            FontSize = templateModel.FontSize;
            Distance = templateModel.Distance;
            LineWidth = templateModel.LineWidth;
        }

        private void Dc_DataSelectedEvent(object sender)
        {
            foreach(var dc in dataControls)
            {
                if (dc != (sender as DataBlockControl))
                    dc.Selected = false;
            }
        }

        private void DataModelView_Load(object sender, EventArgs e)
        {
            ResetArea();
        }
    }
}
