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
using System.Drawing.Text;

namespace PrintFieldsLocationSetting.WinformControls
{
    public partial class DataBlockModelProperty : UserControl
    {
        BindingList<PropertyValue> bl_PV = new BindingList<PropertyValue>();
        DataBlockModel currentDataModel = new DataBlockModel();
        public DataBlockModel CurrentDataModel
        {
            get { return currentDataModel; }
            set
            {
                ColumnWidth = value.ColumnWidth;
                ColumnName = value.ColumnName;
                DataName = value.DataName;
            }
        }

        public int ColumnWidth
        {
            set
            {
                tb_Width.Text = value.ToString();
                bl_PV[0].Value = value.ToString();
                currentDataModel.ColumnWidth = value;
                dgv_DataModelProperty.Refresh();
                //通知选中项改变属性
                if (DataBlockControl.Current == null)
                    return;
                DataBlockControl.Current.ColumnWidth = value;
            }
        }

        public string ColumnName
        {
            set
            {
                tb_ColumnName.Text = value;
                bl_PV[1].Value = value;
                currentDataModel.ColumnName = value;
                dgv_DataModelProperty.Refresh();
                //通知选中项改变属性
                if (DataBlockControl.Current == null)
                    return;
                DataBlockControl.Current.ColumnName = value;
            }
        }

        public string DataName
        {
            set
            {
                cb_DataName.Text = value;
                bl_PV[2].Value = value;
                currentDataModel.DataName = value;
                dgv_DataModelProperty.Refresh();
                //通知选中项改变属性
                if (DataBlockControl.Current == null)
                    return;
                DataBlockControl.Current.DataName = value;
            }
        }


        public DataBlockModelProperty()
        {
            InitializeComponent();
            bl_PV.Add(new PropertyValue() { Property = "宽度", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "列名", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "数据", Value = "" });

            dgv_DataModelProperty.DataSource = bl_PV;
        }

        private void DataModelProperty_Load(object sender, EventArgs e)
        {
            CurrentDataModel = DataBlockModel.CreateNewInstance();
            DataTable dt = new DataTable();
            dt.Columns.Add("value", typeof(int));
            dt.Columns.Add("display", typeof(string));
            foreach (var item in PrintDatas.PrintFieldBM)
            {
                dt.Rows.Add(item.ID, item.PrintName);
            }
            cb_DataName.DataSource = dt;
            cb_DataName.DisplayMember = "display";
            cb_DataName.ValueMember = "value";
        }

        private void dgv_DataModelProperty_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;
            switch (e.RowIndex)
            {
                case 0:
                    tb_Width.Visible = true;
                    tb_Width.Focus();
                    break;
                case 1:
                    tb_ColumnName.Visible = true;
                    tb_ColumnName.Focus();
                    break;
                case 2:
                    cb_DataName.Visible = true;
                    cb_DataName.Focus();
                    break;
            }
        }

        private void TriggerValidated(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Validate();
            }
            else if ((sender as Control).Name == "tb_Width")
            {
                if (e.KeyChar != 45 && e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void ValueValidated(object sender, EventArgs e)
        {
            (sender as Control).Visible = false;
        }

        private void tb_Width_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Width.Text))
                return;
            ColumnWidth = int.Parse(tb_Width.Text);
        }

        private void tb_ColumnName_TextChanged(object sender, EventArgs e)
        {
            ColumnName = tb_ColumnName.Text;
        }

        private void cb_DataName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_DataName.SelectedValue == null)
                return;
            DataName = cb_DataName.Text;
        }
    }
}
