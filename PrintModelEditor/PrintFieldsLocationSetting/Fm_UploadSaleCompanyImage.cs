using BLL;
using BLL.Models;
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
    public partial class Fm_UploadSaleCompanyImage : Form
    {
        public Fm_UploadSaleCompanyImage()
        {
            InitializeComponent();
        }

        private void Fm_UploadSaleCompanyImage_Load(object sender, EventArgs e)
        {
            Dictionary<Guid, string> dic2 = MISService.CurrentMISService.GetHeadList();
            List<SaleCompanyDTO> saleCompanyList = new List<SaleCompanyDTO>();
            foreach(KeyValuePair<Guid,string> kv in dic2)
            {
                string CompanyImage = "";
                SaleCompanyDTO scm = PrintDatas.saleCompanyMList.Find(s => s.SaleCompanyID == kv.Key);
                if (scm != null)
                    CompanyImage = scm.SaleCompanyImage;
                saleCompanyList.Add(new SaleCompanyDTO()
                {
                    SaleCompanyID = kv.Key,
                    SaleCompanyName = kv.Value,
                    SaleCompanyImage = CompanyImage
                });
            }
            PrintDatas.saleCompanyMList = saleCompanyList;
            dgv_SaleCompanyImage.DataSource = PrintDatas.saleCompanyMList;
        }

        private void dgv_SaleCompanyImage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_SaleCompanyImage.Columns[e.ColumnIndex].Name == "_saleCompanyImage" && e.RowIndex >= 0)
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "jpg图片|*.jpg";
                if (openfile.ShowDialog() == DialogResult.OK && openfile.FileName != "")
                {
                    string imageName = "express_" + dgv_SaleCompanyImage.CurrentRow.Cells["_saleCompanyID"].Value.ToString() + ".jpg";
                    dgv_SaleCompanyImage.CurrentCell.Value = imageName;
                    PrintDatas.UploadFile(openfile.FileName, imageName);
                }
            }
        }

        private void dgv_SaleCompanyImage_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (dgv_SaleCompanyImage.Columns[dgv_SaleCompanyImage.CurrentCell.ColumnIndex].Name == "_saleCompanyImage"
                && dgv_SaleCompanyImage.CurrentCell.RowIndex >= 0 && e.KeyCode == Keys.Delete)
            {
                if (dgv_SaleCompanyImage.CurrentCell.Value != null)
                {
                    string imageName = dgv_SaleCompanyImage.CurrentCell.Value.ToString();
                    PrintDatas.DeleteImage(imageName);
                    dgv_SaleCompanyImage.CurrentCell.Value = "";
                }
            }
        }
    }
}
