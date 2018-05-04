using PrintFieldsLocationSetting.Models;
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
    public partial class Fm_UploadImage : Form
    {
        BindingSource bs_sign = new BindingSource();
        BindingSource bs_group = new BindingSource();
        BindingSource bs_dgv = new BindingSource();
        public Fm_UploadImage()
        {
            InitializeComponent();
        }

        void BindingSourceReset()
        {
            bs_sign.ResetBindings(false);
            bs_group.ResetBindings(false);
            bs_dgv.DataSource = PrintDatas.pictureGroupLocationMList.Where(p => cb_GroupName.SelectedValue == null
                                                                            || p.GroupID == (Guid)cb_GroupName.SelectedValue);
            bs_dgv.ResetBindings(false);
        }

        private void Fm_UploadImage_Load(object sender, EventArgs e)
        {
            _locationID.DisplayMember = cb_Sign.DisplayMember = "LocationName";
            _locationID.ValueMember = cb_Sign.ValueMember = "ID";
            _groupID.DisplayMember = cb_GroupName.DisplayMember = "GroupName";
            _groupID.ValueMember = cb_GroupName.ValueMember = "ID";

            bs_sign.DataSource = PrintDatas.pictureLocationMList;
            _locationID.DataSource = cb_Sign.DataSource = bs_sign;
            bs_group.DataSource = PrintDatas.pictureGroupMList;
            _groupID.DataSource = cb_GroupName.DataSource = bs_group;
            bs_dgv.DataSource = PrintDatas.pictureGroupLocationMList.Where(p=> cb_GroupName.SelectedValue == null 
                                                                            || p.GroupID == (Guid)cb_GroupName.SelectedValue);
            dgv_PictureGroup.DataSource = bs_dgv;
        }

        private void btn_AddSign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cb_Sign.Text.Trim()))
                return;
            if (PrintDatas.pictureLocationMList.Count(p => p.LocationName == cb_Sign.Text.Trim()) > 0)
            {
                MessageBox.Show("该方位名称已存在!");
                return;
            }
            PictureLocationModel plm = PictureLocationModel.CreateNewInstance();
            plm.LocationName = cb_Sign.Text.Trim();
            PrintDatas.pictureLocationMList.Add(plm);
            foreach (var item in PrintDatas.pictureGroupMList)
            {
                PictureGroupLocationModel pglm = PictureGroupLocationModel.CreateNewInstance();
                pglm.GroupID = item.ID;
                pglm.LocationID = plm.ID;
                PrintDatas.pictureGroupLocationMList.Add(pglm);
            }
            BindingSourceReset();
        }

        private void btn_AddNewGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cb_GroupName.Text.Trim()))
                return;
            if (PrintDatas.pictureGroupMList.Count(p => p.GroupName == cb_GroupName.Text.Trim()) > 0)
            {
                MessageBox.Show("该组名已存在!");
                return;
            }
            PictureGroupModel pgm = PictureGroupModel.CreateNewInstance();
            pgm.GroupName = cb_GroupName.Text.Trim();
            PrintDatas.pictureGroupMList.Add(pgm);
            foreach (var item in PrintDatas.pictureLocationMList)
            {

                PictureGroupLocationModel pglm = PictureGroupLocationModel.CreateNewInstance();
                pglm.GroupID = pgm.ID;
                pglm.LocationID = item.ID;
                PrintDatas.pictureGroupLocationMList.Add(pglm);
            }
            BindingSourceReset();
        }

        private void dgv_PictureGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_PictureGroup.Columns[e.ColumnIndex].Name == "_pictureName" && e.RowIndex >= 0)
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "jpg图片|*.jpg";
                if (openfile.ShowDialog() == DialogResult.OK && openfile.FileName != "")
                {
                    string imageName = dgv_PictureGroup.CurrentRow.Cells["_locationID"].FormattedValue.ToString()
                        + "_" + dgv_PictureGroup.CurrentRow.Cells["_groupID"].FormattedValue.ToString() + ".jpg";
                    dgv_PictureGroup.CurrentCell.Value = imageName;
                    PrintDatas.UploadFile(openfile.FileName, imageName);
                }
            }
        }

        private void btn_DeleteSign_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否删除此方位？\r\n与该方位相关的数据也将一起删除。","提示",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (cb_Sign.SelectedValue == null)
                    return;
                Guid sign_id = (Guid)cb_Sign.SelectedValue;
                List<PictureGroupLocationModel> removeList = PrintDatas.pictureGroupLocationMList.Where(pglm => pglm.LocationID == sign_id).ToList();
                foreach(var item in removeList)
                {
                    PrintDatas.pictureGroupLocationMList.Remove(item);
                }
                foreach(var p in PrintDatas.pictureLocationMList)
                {
                    if(p.ID == sign_id)
                    {
                        PrintDatas.pictureLocationMList.Remove(p);
                        break;
                    }
                }
            }
            BindingSourceReset();
        }

        private void btn_DeleteGroupName_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除此组？\r\n与该组相关的数据也将一起删除。", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (cb_GroupName.SelectedValue == null)
                    return;
                Guid group_id = (Guid)cb_GroupName.SelectedValue;
                List<PictureGroupLocationModel> removeList = PrintDatas.pictureGroupLocationMList.Where(pglm => pglm.GroupID == group_id).ToList();
                foreach (var item in removeList)
                {
                    PrintDatas.pictureGroupLocationMList.Remove(item);
                }
                foreach (var p in PrintDatas.pictureGroupMList)
                {
                    if (p.ID == group_id)
                    {
                        PrintDatas.pictureGroupMList.Remove(p);
                        break;
                    }
                }
            }
            BindingSourceReset();
        }

        private void Fm_UploadImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
        }

        private void btn_UploadSaleCompanyImage_Click(object sender, EventArgs e)
        {
            new Fm_UploadSaleCompanyImage().ShowDialog();
        }

        private void dgv_PictureGroup_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (dgv_PictureGroup.Columns[dgv_PictureGroup.CurrentCell.ColumnIndex].Name == "_pictureName"
                && dgv_PictureGroup.CurrentCell.RowIndex >= 0 && e.KeyCode == Keys.Delete)
            {
                if (dgv_PictureGroup.CurrentCell.Value != null)
                {
                    string imageName = dgv_PictureGroup.CurrentCell.Value.ToString();
                    PrintDatas.DeleteImage(imageName);
                    dgv_PictureGroup.CurrentCell.Value = "";
                }
            }
        }

        private void cb_GroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs_dgv.DataSource = PrintDatas.pictureGroupLocationMList.Where(p => cb_GroupName.SelectedValue == null
                                                                            || p.GroupID == (Guid)cb_GroupName.SelectedValue);
            bs_dgv.ResetBindings(false);
        }
    }
}
