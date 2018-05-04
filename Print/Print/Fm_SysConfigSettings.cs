using BLL;
using DataEntity;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print
{
    public partial class Fm_SysConfigSettings : Form
    {
        private static Dictionary<Guid, PrintExpressDTO> PrintExpressDtoDic = new Dictionary<Guid, PrintExpressDTO>();
        public Fm_SysConfigSettings()
        {
            InitializeComponent();
        }

        void Load_PrinterSettings()
        {

        }

        void Load_Express()
        {
            try
            {
                var expList = ConfigManager.ConfigInfo.ExpList;

                if (PrintExpressDtoDic.Count == 0)
                {
                    var result = WMSService.CurrentWMSService.GetExpressByWarehouseId(new Guid(ConfigManager.ConfigInfo.WarehouseId));
                    if (result.IsSuccess)
                    {
                        PrintExpressDtoDic = result.Data.ToDictionary(ent => ent.ExpressId, ent => ent);
                    }
                    else
                    {
                        MessageBox.Show(result.Msg, @"注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                _expressCompanyID.DataSource = PrintExpressDtoDic.Values.Select(v =>
                    new
                    {
                        ExpressID = v.ExpressId,
                        ExpressName = v.ExpressName
                    }
                    ).ToArray();
                _expressCompanyID.DisplayMember = "ExpressName";
                _expressCompanyID.ValueMember = "ExpressId";
                var templateList = DataManager.TemplateM.Select(t =>
                new
                {
                    TemplateID = t.ModelID,
                    TemplateName = t.ModelName + "[" + t.CompanyName + "]"
                }).ToList();
                templateList.Insert(0, new
                {
                    TemplateID = new Guid(),
                    TemplateName = ""
                });
                _expressPrintModel.DataSource = templateList;
                _expressPrintModel.DisplayMember = "TemplateName";
                _expressPrintModel.ValueMember = "TemplateID";
                var pictureGroupList = DataManager.PictureGroupM;
                _pictureGroup.DataSource = pictureGroupList;
                _pictureGroup.DisplayMember = "GroupName";
                _pictureGroup.ValueMember = "ID";

                _orderPrinter.DataSource = PrinterSystemConfig.GetPrinterList();
                _expressPrinter.DataSource = PrinterSystemConfig.GetPrinterList();
                BindingList<ExpressAutoPrintDTO> expressBindingList = new BindingList<ExpressAutoPrintDTO>(
                    PrintExpressDtoDic.Values.Select(ped => {
                        var expLocal = expList.Find(exp => exp.ExpressCompanyId == ped.ExpressId);
                        return new ExpressAutoPrintDTO()
                        {
                            ExpressCompanyId = ped.ExpressId,
                            Selected = expLocal == null ? false : expLocal.Selected,
                            AutoPrint = expLocal == null ? false : expLocal.AutoPrint,
                            ExpressPrintModel = (expLocal == null || DataManager.TemplateM.Find(t=>t.ModelID == expLocal.ExpressPrintModel) == null)
                                                ? new Guid() : expLocal.ExpressPrintModel,
                            OrderPrinter = (expLocal == null || !PrinterSystemConfig.GetPrinterList().Contains(expLocal.OrderPrinter)) 
                                                ? "" : expLocal.OrderPrinter,
                            ExpressPrinter = (expLocal == null || !PrinterSystemConfig.GetPrinterList().Contains(expLocal.ExpressPrinter))
                                                ? "" : expLocal.ExpressPrinter,
                            PictureGroup = (expLocal == null || DataManager.PictureGroupM.Find(p => p.ID == expLocal.PictureGroup) == null)
                                                ? new Guid() : expLocal.PictureGroup
                        };
                    }).ToArray());
                BindingSource bs = new BindingSource();
                bs.DataSource = expressBindingList;
                dgv_Express.DataSource = bs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"加载异常" + ex.ToString(), @"注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tab_SystemSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tab_SystemSet.SelectedTab == Express)
            {
                Load_Express();
            }
        }

        private Color GetColor(byte index)
        {
            switch (index)
            {
                case 1:
                    return Color.DarkGray;
                case 2:
                    return Color.LightGray;
                case 3:
                    return Color.DimGray;
                case 4:
                    return Color.Beige;
                case 5:
                    return Color.CadetBlue;
                case 6:
                    return Color.LightSeaGreen;
                case 7:
                    return Color.LightSteelBlue;
                default:
                    return Color.White;
            }
        }

        private void Fm_SysConfigSettings_Load(object sender, EventArgs e)
        {
            Load_Express();
        }

        private void btn_PrintPlatformSet_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigManager.ConfigInfo.ExpList = (dgv_Express.DataSource as BindingSource).Cast<ExpressAutoPrintDTO>().ToList();
                ConfigManager.SaveConfig();
                this.Close();
            }
            catch
            {
                MessageBox.Show("操作失败!", "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_quit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
