using PrintFieldsLocationSetting.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PrintFieldsLocationSetting
{
    public partial class Fm_PageSetting : Form
    {
        public Fm_PageSetting(PageModel pm = null)
        {
            InitializeComponent();
            if (pm == null)
            {
                pm = PageModel.CreateNewPage();
            }
            tb_PageName.Text = pm.PageName;
            nud_PageWidth.Value = pm.Width;
            nud_PageHeight.Value = pm.Height;
            nud_Padding.Value = pm.Padding;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            PrintDatas.pageMList.Remove(PrintDatas.pageMList.Where(p => p.PageName == tb_PageName.Text.Trim()).FirstOrDefault());
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            PageModel pm = PrintDatas.pageMList.Where(p => p.PageName == tb_PageName.Text.Trim()).FirstOrDefault();
            if (pm != null)
            {
                pm.Width = (int)nud_PageWidth.Value;
                pm.Height = (int)nud_PageHeight.Value;
                pm.Padding = (int)nud_Padding.Value;
            }
            else
            {
                PrintDatas.pageMList.Add(new PageModel()
                {
                    PageID = Guid.NewGuid(),
                    PageName = tb_PageName.Text.Trim(),
                    Width = (int)nud_PageWidth.Value,
                    Height = (int)nud_PageHeight.Value,
                    Padding = (int)nud_Padding.Value,
                });
            }
            this.Close();
        }
    }
}
