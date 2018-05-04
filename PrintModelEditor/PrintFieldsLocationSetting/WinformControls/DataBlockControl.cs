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
    public partial class DataBlockControl : UserControl
    {
        public delegate void DataSelectedHandle(object sender);
        public event DataSelectedHandle DataSelectedEvent;
        public delegate void DataKeyDownHandle(PreviewKeyDownEventArgs e);
        public event DataKeyDownHandle DataKeyDownEvent;
        bool onlyShow;
        int lineWidth;
        bool selected;
        static DataBlockControl current;
        public decimal Percentage { get; set; }
        public static DataBlockControl Current
        {
            get { return current; }
            set
            {
                current = value;
                PaintManager.fm_DataModel.CurrentView.CurrentProperty.CurrentDataModel = value.CurrentModel;
            }
        }
        DataBlockModel currentModel = DataBlockModel.CreateNewInstance();

        public DataBlockModel CurrentModel
        {
            get { return currentModel; }
            set
            {
                currentModel = value;
                ColumnWidth = value.ColumnWidth;
                ColumnName = value.ColumnName;
                DataName = value.DataName;
            }
        }
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (value)
                {
                    this.BackColor = Color.LightPink;
                    Current = this;
                    DataSelectedEvent(this);
                }
                else
                {
                    this.BackColor = Color.White;
                }
            }
        }

        public string FontFamilyName
        {
            set
            {
                lb_DataName.Font = lb_ColumnName.Font = new Font(value, (float)((decimal)lb_DataName.Font.Size * Percentage));
            }
        }

        public float FontSize
        {
            set
            {
                lb_DataName.Font = lb_ColumnName.Font = new Font(lb_DataName.Font.Name, (float)((decimal)value * Percentage));
            }
        }

        public int ColumnWidth
        {
            set
            {
                CurrentModel.ColumnWidth = value;
                this.Width = (int)(value * Percentage);
            }
        }

        public string ColumnName
        {
            set
            {
                CurrentModel.ColumnName = value;
                lb_ColumnName.Text = value;
            }
        }

        public string DataName
        {
            set
            {
                CurrentModel.DataName = value;
                lb_DataName.Text = value;
            }
        }

        public int Distance
        {
            set
            {
                pn_Distance.Height = (int)(value * Percentage);
            }
        }

        public int LineWidth
        {
            set
            {
                lineWidth = value;
                pn_SplitBottom.Height = pn_SplitTop.Height = (int)(lineWidth * Percentage);
            }
        }

        public DataBlockControl(decimal percentage,DataBlockModel dataBlockModel,bool onlyShow)
        {
            InitializeComponent();
            this.onlyShow = onlyShow;
            this.Percentage = percentage;
            this.CurrentModel = dataBlockModel;
        }

        private void DataControl_MouseClick(object sender, MouseEventArgs e)
        {
            this.Selected = true;
        }

        private void DataControl_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.Delete)
            //{
            //    this.Parent.Controls.Remove(this);
            //}
        }

        private void DataBlockControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (onlyShow)
                DataKeyDownEvent(e);
        }
    }
}
