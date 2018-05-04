using Newtonsoft.Json;
using PrintFieldsLocationSetting.Models;
using PrintFieldsLocationSetting.WinformControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace PrintFieldsLocationSetting
{
    public partial class Fm_FieldsLocationSetting : Form
    {
        DataTable dtPages = new DataTable();
        DataTable dtModels = new DataTable();
        public Fm_FieldsLocationSetting()
        {
            InitializeComponent();
        }

        void ChangeToBindingPage()
        {
            if (cb_Model.SelectedValue == null)
                return;
            TemplateModel pModel = cb_Model.SelectedValue as TemplateModel;
            if (pModel.BindingPage == new Guid())
            {
                cb_Binding.Checked = false;
                return;
            }
            foreach (DataRow row in dtPages.Rows)
            {
                PageModel pm = row[1] as PageModel;
                if (pm.PageID == pModel.BindingPage)
                {
                    cb_PageSize.Text = row[0].ToString();
                    cb_Binding.Checked = true;
                    return;
                }
            }
        }

        void RefreshBinding()
        {
            if (cb_Model.SelectedValue != null
                && cb_PageSize.SelectedValue != null)
            {
                TemplateModel pm = cb_Model.SelectedValue as TemplateModel;
                PageModel pagem = cb_PageSize.SelectedValue as PageModel;
                if (pm.BindingPage == pagem.PageID)
                    cb_Binding.Checked = true;
                else
                    cb_Binding.Checked = false;
            }
            else
                cb_Binding.Checked = false;
        }

        void BindingModels()
        {
            TemplateModel _pm = null;
            if (dtModels.Rows.Count > 0)
            {
                _pm = cb_Model.SelectedValue as TemplateModel;
            }
            PrintDatas.templateMList = PrintDatas.templateMList.OrderBy(p => p.ModelName).ToList();
            string findModel = null;
            dtModels.Rows.Clear();
            foreach (TemplateModel pm in PrintDatas.templateMList)
            {
                if (_pm != null && pm.ModelName == _pm.ModelName)
                {
                    findModel = string.Format("{0} -- {1}", pm.ModelName, pm.CompanyName);
                }
                dtModels.Rows.Add(string.Format("{0} -- {1}", pm.ModelName, pm.CompanyName), pm);
            }
            cb_Model.DataSource = dtModels;
            if (!string.IsNullOrEmpty(findModel))
                cb_Model.Text = findModel;
            ChangeToBindingPage();
            BindingData();
        }

        void BindingPages()
        {
            cb_PagePadding.Checked = false;
            //之前选择的纸张
            PageModel _pm = null;
            if (dtPages.Rows.Count > 0)
            {
                _pm = cb_PageSize.SelectedValue as PageModel;
            }
            //重新加载数据
            dtPages.Rows.Clear();
            PrintDatas.pageMList = PrintDatas.pageMList.OrderBy(p => p.PageName).ToList();
            //设置页面大小
            string findPage = null;
            foreach (PageModel pm in PrintDatas.pageMList)
            {
                if (_pm != null && pm.PageName == _pm.PageName)
                {
                    findPage = string.Format("{0}:{1} × {2}", pm.PageName, pm.Width, pm.Height);
                }
                dtPages.Rows.Add(string.Format("{0}:{1} × {2}", pm.PageName, pm.Width, pm.Height), pm);
            }
            cb_PageSize.DataSource = dtPages;
            //重新选择之前的纸张
            if (!string.IsNullOrEmpty(findPage))
                cb_PageSize.Text = findPage;
            PaintManager.PageSizeSelectionChanged(cb_PageSize.SelectedValue as PageModel);
            nud_PagePadding.Value = cb_PageSize.SelectedValue == null ? 0 : (cb_PageSize.SelectedValue as PageModel).Padding;
            nud_BlankWhite.Value = cb_PageSize.SelectedValue == null ? 0 : PaintConvert.Pix2Millimeter((cb_PageSize.SelectedValue as PageModel).BlankHeight);
            nud_UnSplitBlock.Value = cb_PageSize.SelectedValue == null ? 0 : PaintConvert.Pix2Millimeter((cb_PageSize.SelectedValue as PageModel).UnSplitBlockHeight);
            RefreshBinding();
        }

        void BindingData()
        {
            Guid modelID = new Guid();
            if (cb_Model.SelectedValue != null)
            {
                modelID = (cb_Model.SelectedValue as TemplateModel).ModelID;
            }
            PaintManager.CurrentDataManager.BindingData(modelID);
        }

        private void PaintManager_FieldControlLocationChangedEvent(Point location)
        {
            lb_X.Text = string.Format("X:{0}", location.X);
            lb_Y.Text = string.Format("Y:{0}", location.Y);
        }

        private void PaintManager_PageSizePercentChangedEvent(int percentage)
        {
            this.tb_SizePercent.Value = percentage;
            this.lb_SizePercent.Text = string.Format("{0}%", this.tb_SizePercent.Value);
        }

        private void tb_SizePercent_Scroll(object sender, EventArgs e)
        {
            PaintManager.SizePercentNow = (decimal)tb_SizePercent.Value / 100;
        }

        private void cb_PageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            tt_CbBox.SetToolTip(cb_PageSize, cb_PageSize.Text);
            cb_PagePadding.Checked = false;
            PaintManager.PageSizeSelectionChanged(cb_PageSize.SelectedValue as PageModel);
            nud_PagePadding.Value = cb_PageSize.SelectedValue == null ? 0 : (cb_PageSize.SelectedValue as PageModel).Padding;
            nud_BlankWhite.Value = cb_PageSize.SelectedValue == null ? 0 : PaintConvert.Pix2Millimeter((cb_PageSize.SelectedValue as PageModel).BlankHeight);
            nud_UnSplitBlock.Value = cb_PageSize.SelectedValue == null ? 0 : PaintConvert.Pix2Millimeter((cb_PageSize.SelectedValue as PageModel).UnSplitBlockHeight);
            RefreshBinding();
        }

        private void nud_PagePadding_ValueChanged(object sender, EventArgs e)
        {
            PaintManager.SetPaddingLine((int)nud_PagePadding.Value);
            if (cb_PageSize.SelectedValue != null)
            {
                PrintDatas.pageMList.Find(p => p.PageID == (cb_PageSize.SelectedValue as PageModel).PageID).Padding = (int)nud_PagePadding.Value;
            }
        }

        private void cb_PagePadding_CheckedChanged(object sender, EventArgs e)
        {
            PaintManager.ChangeEnable(cb_PagePadding.Checked);
        }

        private void Fm_FieldsLocationSetting_Load(object sender, EventArgs e)
        {
            #region 绑定各项用户控件
            //编辑界面
            PaintManager.CurrentView = pv_Current;
            //数据管理
            PaintManager.CurrentDataManager = dm_Fields;
            //窗口百分比（暂时停用缩放功能）
            PaintManager.CurrentView.SizePercentNow = PaintManager.SizePercentNow;
            #endregion
            #region 从服务器上加载数据
            PrintDatas.SyncDataFromServer();
            #endregion
            #region 事件绑定
            //打印显示百分比变化事件（缩放功能，暂停用）
            PaintManager.PageSizePercentChangedEvent += PaintManager_PageSizePercentChangedEvent;
            //字段控件位置变化事件
            PaintManager.FieldControlLocationChangedEvent += PaintManager_FieldControlLocationChangedEvent;
            //模板名称新增事件
            Fm_AddNewModel.HasTheSameModelNameEvent += Fm_AddNewModel_HasTheSameModelNameEvent;
            #endregion
            #region DataTable初始化
            //纸张
            dtPages.Columns.Add("display", typeof(string));
            dtPages.Columns.Add("value", typeof(PageModel));
            cb_PageSize.DisplayMember = "display";
            cb_PageSize.ValueMember = "value";
            //打印模板
            dtModels.Columns.Add("display", typeof(string));
            dtModels.Columns.Add("value", typeof(TemplateModel));
            cb_Model.DisplayMember = "display";
            cb_Model.ValueMember = "value";
            #endregion
            #region 绑定数据
            //绑定纸张
            BindingPages();
            //绑定打印模板
            BindingModels();
            #endregion
            #region 初始化窗体布局
            cb_Binding.Width = btn_Remove.Width = btn_Copy.Width = btn_Paste.Width = pn_ModelBtns.Width / 4;
            #endregion
        }

        private bool Fm_AddNewModel_HasTheSameModelNameEvent(TemplateModel model)
        {
            //检查模板是否有重名存在
            foreach (DataRow row in dtModels.Rows)
            {
                if ((row["value"] as TemplateModel).ModelName == model.ModelName)
                    return true;
            }
            //没有重名则新增该模板
            model.ModelID = Guid.NewGuid();
            cb_Binding.Checked = true;
            PrintDatas.templateMList.Add(model);
            BindingModels();
            return false;
        }

        private void cb_Model_SelectedIndexChanged(object sender, EventArgs e)
        {
            tt_CbBox.SetToolTip(cb_Model, cb_Model.Text);
            ChangeToBindingPage();
            PaintManager.CurrentView.CleanBackgroundImage();
            BindingData();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除该模板？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            TemplateModel pm = cb_Model.SelectedValue as TemplateModel;
            PaintManager.CurrentDataManager.DeleteDataByModel(pm.ModelID);
            PrintDatas.templateMList = PrintDatas.templateMList.Where(p => p.ModelID != pm.ModelID).ToList();
            BindingModels();
            BindingData();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            if (cb_Model.SelectedValue != null)
            {
                PaintManager.CopyModelId = (cb_Model.SelectedValue as TemplateModel).ModelID;
                btn_Copy.BackColor = Color.LightGreen;
                tt_CbBox.SetToolTip(btn_Copy, cb_Model.Text);
            }
        }

        private void btn_Paste_Click(object sender, EventArgs e)
        {
            if (PaintManager.CopyModelId != new Guid()
                && cb_Model.SelectedValue != null
                && (cb_Model.SelectedValue as TemplateModel).ModelID != PaintManager.CopyModelId)
            {
                if (PaintManager.CurrentDataManager.BindingListCount() > 0)
                {
                    if (MessageBox.Show("粘贴将覆盖当前模板的所有数据，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                PaintManager.CurrentDataManager.PasteModelData((cb_Model.SelectedValue as TemplateModel).ModelID);
                PaintManager.CopyModelId = new Guid();
                btn_Copy.BackColor = Color.White;
                tt_CbBox.SetToolTip(btn_Copy, "");
            }
        }

        private void Fm_FieldsLocationSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            PaintManager.CurrentView.UnSelectAll();
            if(PaintManager.CurrentDataManager.NeedSyncDataFile())
            {
                if (MessageBox.Show("确定关闭吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void pn_ModelBtns_SizeChanged(object sender, EventArgs e)
        {
            cb_Binding.Width = btn_Remove.Width = btn_Copy.Width = btn_Paste.Width = pn_ModelBtns.Width / 4;
        }

        private void btn_PageSettings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new Fm_PageSetting(cb_PageSize.SelectedValue as PageModel).ShowDialog();
            BindingPages();
        }

        private void lb_Model_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TemplateModel pm = TemplateModel.Create();
            if (dtModels.Rows.Count > 0)
                pm = cb_Model.SelectedValue as TemplateModel;
            new Fm_AddNewModel(pm).ShowDialog();
        }

        private void cb_Binding_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Model.SelectedValue == null
                    || cb_PageSize.SelectedValue == null)
            {
                cb_Binding.Checked = false;
                return;
            }
            if (cb_Binding.Checked)
            {
                TemplateModel pm = cb_Model.SelectedValue as TemplateModel;
                PageModel pagem = cb_PageSize.SelectedValue as PageModel;
                pm.BindingPage = pagem.PageID;
            }
            else
            {
                TemplateModel pm = cb_Model.SelectedValue as TemplateModel;
                PageModel pagem = cb_PageSize.SelectedValue as PageModel;
                if (pm.BindingPage == pagem.PageID)
                    pm.BindingPage = new Guid();
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            PaintManager.CurrentView.UnSelectAll();
            PrintDatas.SyncDataToServer();
            MessageBox.Show("保存成功！");
        }

        private void btn_DataModel_Click(object sender, EventArgs e)
        {
            if (PaintManager.CurrentView.FixedPageSize == new Size(0,0))
            {
                MessageBox.Show("请选择纸张", "提示");
                return;
            }
            PaintManager.fm_DataModel.Show(PaintManager.CurrentView.FixedPageSize.Width, 1);
        }

        private void nud_BlankWhite_ValueChanged(object sender, EventArgs e)
        {
            int pixValue = PaintConvert.Millimeter2Pix((int)nud_BlankWhite.Value);
            PaintManager.ChangeBlankHeight(pixValue);
            if (cb_PageSize.SelectedValue != null)
            {
                PrintDatas.pageMList.Find(p => p.PageID == (cb_PageSize.SelectedValue as PageModel).PageID).BlankHeight 
                    = pixValue;
            }
        }

        private void nud_UnSplitBlock_ValueChanged(object sender, EventArgs e)
        {
            int pixValue = PaintConvert.Millimeter2Pix((int)nud_UnSplitBlock.Value);
            PaintManager.ChangeUnSplitBlockHeight(pixValue);
            if (cb_PageSize.SelectedValue != null)
            {
                PrintDatas.pageMList.Find(p => p.PageID == (cb_PageSize.SelectedValue as PageModel).PageID).UnSplitBlockHeight
                    = pixValue;
            }
        }

        private void btn_UploadImage_Click(object sender, EventArgs e)
        {
            new Fm_UploadImage().ShowDialog();
        }

        private void btn_SenderSettings_Click(object sender, EventArgs e)
        {
            Fm_SenderSettings.CurrentFmSenderSettings.ShowDialog();
        }
    }
}
