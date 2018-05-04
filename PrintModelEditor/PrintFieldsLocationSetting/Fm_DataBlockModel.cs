using PrintFieldsLocationSetting.WinformControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrintFieldsLocationSetting.Models;

namespace PrintFieldsLocationSetting
{
    public partial class Fm_DataModel : Form
    {
        static Fm_DataModel formDataModel;
        int pageWidth;
        BindingList<DataBlockTemplateModel> dataBlockModelBList = new BindingList<DataBlockTemplateModel>();

        private Fm_DataModel()
        {
            InitializeComponent();
            //设置字体
            List<string> fontFamilyNames = new List<string>();
            FontFamily[] fontFamilies = new InstalledFontCollection().Families;
            foreach (FontFamily f in fontFamilies)
                fontFamilyNames.Add(f.Name);
            cb_FontFamily.DataSource = fontFamilyNames;
            if (fontFamilyNames.Count(fn => fn == "宋体") > 0)
                cb_FontFamily.Text = "宋体";
        }

        public static Fm_DataModel FormDataModel
        {
            get
            {
                if (formDataModel == null)
                    formDataModel = new Fm_DataModel();
                return formDataModel;
            }
        }

        public DataBlockModelView CurrentView
        {
            get { return uc_CurrentDataModelView; }
        }

        private void Fm_DataModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        public void Show(int pageWidth,decimal percentage)
        {
            uc_CurrentDataModelView.Percentage = percentage;
            if (this.pageWidth != pageWidth)
            {
                this.pageWidth = pageWidth;
                dataBlockModelBList = new BindingList<DataBlockTemplateModel>(PrintDatas.dataBlockTMList.
                    Where(t => t.PageWidth == pageWidth).OrderBy(t => t.ModelName).ToList());
                dgv_DataModelTemplate.DataSource = dataBlockModelBList;
                if (dataBlockModelBList.Count > 0)
                    uc_CurrentDataModelView.AddDataControls(dataBlockModelBList[0]);
                else
                {
                    uc_CurrentDataModelView.PageWidth = pageWidth;
                    uc_CurrentDataModelView.PaddingLeft = (int)nud_PaddingLeft.Value;
                    uc_CurrentDataModelView.PaddingTop = (int)nud_PaddingTop.Value;
                    uc_CurrentDataModelView.PaddingRight = (int)nud_PaddingRight.Value;
                    uc_CurrentDataModelView.PaddingBottom = (int)nud_PaddingBottom.Value;
                    uc_CurrentDataModelView.RemoveAllDataBlockControls();
                }
            }
            this.Show();
        }

        private void uc_CurrentDataModelView_SizeChanged(object sender, EventArgs e)
        {
            uc_CurrentDataModelView.CenterToCenter();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (new Fm_AddNewDataBlockTemplate().ShowDialog() == DialogResult.Cancel)
                return;
            uc_CurrentDataModelView.Edit = false;
            btn_Edit.Text = "编辑";
            DataBlockTemplateModel newModel = DataBlockTemplateModel.CreateNewInstance(Fm_AddNewDataBlockTemplate.ModelName,
                cb_FontFamily.SelectedValue.ToString(), (float)nud_FontSize.Value,
                pageWidth, (int)nud_ColumnNum.Value,(int)nud_Distance.Value,(int)nud_LineWidth.Value,
                (int)nud_PaddingLeft.Value, (int)nud_PaddingTop.Value, (int)nud_PaddingRight.Value, (int)nud_PaddingBottom.Value);
            PrintDatas.dataBlockTMList.Add(newModel);
            dataBlockModelBList.Add(newModel);
            foreach(DataGridViewRow row in dgv_DataModelTemplate.Rows)
            {
                DataBlockTemplateModel dbtm = row.DataBoundItem as DataBlockTemplateModel;
                if (dbtm.ModelID == newModel.ModelID)
                {
                    row.Selected = true;
                    break;
                }
            }
            uc_CurrentDataModelView.AddDataControls(newModel);
        }

        private void nud_PaddingTop_ValueChanged(object sender, EventArgs e)
        {
            if(uc_CurrentDataModelView.Edit)
                uc_CurrentDataModelView.PaddingTop = (int)nud_PaddingTop.Value;
        }

        private void nud_PaddingBottom_ValueChanged(object sender, EventArgs e)
        {
            if (uc_CurrentDataModelView.Edit)
                uc_CurrentDataModelView.PaddingBottom = (int)nud_PaddingBottom.Value;
        }

        private void nud_PaddingLeft_ValueChanged(object sender, EventArgs e)
        {
            if (uc_CurrentDataModelView.Edit)
                uc_CurrentDataModelView.PaddingLeft = (int)nud_PaddingLeft.Value;
        }

        private void nud_PaddingRight_ValueChanged(object sender, EventArgs e)
        {
            if (uc_CurrentDataModelView.Edit)
                uc_CurrentDataModelView.PaddingRight = (int)nud_PaddingRight.Value;
        }

        private void nud_LineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (uc_CurrentDataModelView.Edit)
                uc_CurrentDataModelView.LineWidth = (int)nud_LineWidth.Value;
        }

        private void cb_FontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_FontFamily.SelectedValue == null
                && uc_CurrentDataModelView.Edit)
                return;
            uc_CurrentDataModelView.FontFamilyName = cb_FontFamily.SelectedValue.ToString();
        }

        private void nup_FontSize_ValueChanged(object sender, EventArgs e)
        {
            if (uc_CurrentDataModelView.Edit)
                uc_CurrentDataModelView.FontSize = (float)nud_FontSize.Value;
        }

        private void nud_Distance_ValueChanged(object sender, EventArgs e)
        {
            if (uc_CurrentDataModelView.Edit)
                uc_CurrentDataModelView.Distance = (int)nud_Distance.Value;
        }

        private void dgv_DataModelTemplate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DataModelTemplate.SelectedRows.Count == 0)
            {
                foreach (DataGridViewRow row in dgv_DataModelTemplate.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgv_DataModelTemplate.Rows)
                {
                    if (row != dgv_DataModelTemplate.SelectedRows[0])
                        row.DefaultCellStyle.BackColor = Color.White;
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSeaGreen;
                        DataBlockTemplateModel dbtm = row.DataBoundItem as DataBlockTemplateModel;
                        uc_CurrentDataModelView.AddDataControls(dbtm);
                        nud_PaddingLeft.Value = dbtm.PaddingLeft;
                        nud_PaddingTop.Value = dbtm.PaddingTop;
                        nud_PaddingRight.Value = dbtm.PaddingRight;
                        nud_PaddingBottom.Value = dbtm.PaddingBottom;
                        cb_FontFamily.Text = dbtm.FontFamilyName;
                        nud_FontSize.Value = (decimal)dbtm.FontSize;
                        nud_Distance.Value = dbtm.Distance;
                        nud_ColumnNum.Value = dbtm.ColumnNum;
                        nud_LineWidth.Value = dbtm.LineWidth;
                    }
                }
            }
        }

        private void dgv_DataModelTemplate_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataBlockTemplateModel currentModel = e.Row.DataBoundItem as DataBlockTemplateModel;
            uc_CurrentDataModelView.DeleteAllBlockControls(currentModel.ModelID);
            PrintDatas.dataBlockMList = PrintDatas.dataBlockMList.Where(d => d.TemplateModelID != currentModel.ModelID).ToList();
            PrintDatas.dataBlockTMList.Remove(currentModel);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if(dgv_DataModelTemplate.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择模板", "提示");
                return;
            }
            if (!uc_CurrentDataModelView.Edit)
            {
                uc_CurrentDataModelView.Edit = true;
                btn_Edit.Text = "保存";
            }
            else
            {
                uc_CurrentDataModelView.Edit = false;
                btn_Edit.Text = "编辑";
            }
        }
    }
}
