using PrintFieldsLocationSetting.Models;
using System;
using System.Windows.Forms;

namespace PrintFieldsLocationSetting
{
    public partial class Fm_AddNewModel : Form
    {
        public delegate bool HasTheSameModelNameHandle(TemplateModel model);
        public static event HasTheSameModelNameHandle HasTheSameModelNameEvent;
        public Fm_AddNewModel(TemplateModel pm)
        {
            InitializeComponent();
            tb_ModelName.Text = pm.ModelName;
            tb_CompanyName.Text = pm.CompanyName;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_ModelName.Text.Trim()))
            {
                MessageBox.Show("模板名不能为空！");
                tb_ModelName.Focus();
                return;
            }
            if (!HasTheSameModelNameEvent(new TemplateModel()
            {
                ModelName = tb_ModelName.Text.Trim(),
                CompanyName = tb_CompanyName.Text.Trim()
            }))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("模板名已存在！");
                tb_ModelName.Focus();
                return;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
