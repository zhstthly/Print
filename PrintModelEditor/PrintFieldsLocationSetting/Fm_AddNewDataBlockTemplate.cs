using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintFieldsLocationSetting
{
    public partial class Fm_AddNewDataBlockTemplate : Form
    {
        static string modelName;
        public static string ModelName
        {
            get
            {
                string returnStr = modelName;
                modelName = null;
                return returnStr;
            }
            set
            {
                modelName = value;
            }
        }
        public Fm_AddNewDataBlockTemplate()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_ModelName.Text))
            {
                MessageBox.Show("请填写模板名称", "提示");
                tb_ModelName.Focus();
                return;
            }
            ModelName = tb_ModelName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ModelName = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
