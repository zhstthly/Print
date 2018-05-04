using BLL;
using Infrastructure;
using System;
using System.Collections;
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
    public partial class Fm_ConfigSettings : Form
    {
        public Fm_ConfigSettings()
        {
            InitializeComponent();
        }

        private void bt_CompanyOk_Click(object sender, EventArgs e)
        {
            ConfigManager.ConfigInfo.WarehouseId = ((DictionaryEntry)cmb_Warehouse.SelectedItem).Key == null ? ""
                : ((DictionaryEntry)cmb_Warehouse.SelectedItem).Key.ToString();
            ConfigManager.ConfigInfo.CompanyId = ((DictionaryEntry)cmb_Company.SelectedItem).Key == null ? ""
                : ((DictionaryEntry)cmb_Company.SelectedItem).Key.ToString();
            ConfigManager.ConfigInfo.InvoiceFilialeId = ((DictionaryEntry)cmb_Filiale.SelectedItem).Key == null ? ""
                : ((DictionaryEntry)cmb_Filiale.SelectedItem).Key.ToString();
            ConfigManager.ConfigInfo.OrderType = ((DictionaryEntry)cb_OrderType.SelectedItem).Key == null ? 0
                : int.Parse(((DictionaryEntry)cb_OrderType.SelectedItem).Key.ToString());
            ConfigManager.ConfigInfo.PrintOrderModel = cb_PrintOrderModel.SelectedValue == null ? new Guid() :
                (Guid)cb_PrintOrderModel.SelectedValue;
            ConfigManager.SaveConfig();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fm_ConfigSettings_Load(object sender, EventArgs e)
        {
            // 公司设置
            Dictionary<Guid, string> dic = MISService.CurrentMISService.GetAllCompanys();
            cmb_Company.Items.Clear();

            foreach (KeyValuePair<Guid, string> kvp in dic)
            {
                cmb_Company.Items.Add(new DictionaryEntry(kvp.Key, kvp.Value));
            }
            cmb_Company.DisplayMember = "value";
            cmb_Company.ValueMember = "key";
            cmb_Filiale.Items.Clear();
            Dictionary<Guid, string> dic2 = MISService.CurrentMISService.GetHeadList();
            foreach (KeyValuePair<Guid, string> kvp in dic2)
            {
                cmb_Filiale.Items.Add(new DictionaryEntry(kvp.Key, kvp.Value));
            }
            cmb_Filiale.DisplayMember = "value";
            cmb_Filiale.ValueMember = "key";

            for (int i = 0; i < cmb_Company.Items.Count; i++)
            {
                if (((DictionaryEntry)cmb_Company.Items[i]).Key.ToString() == ConfigManager.ConfigInfo.CompanyId)
                {
                    cmb_Company.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < cmb_Filiale.Items.Count; i++)
            {
                if (((DictionaryEntry)cmb_Filiale.Items[i]).Key.ToString() == ConfigManager.ConfigInfo.InvoiceFilialeId)
                {
                    cmb_Filiale.SelectedIndex = i;
                    break;
                }
            }

            //仓库设置
            var result = WMSService.CurrentWMSService.GetAllUseWarehouse();
            if (result.IsSuccess)
            {
                cmb_Warehouse.Items.Clear();
                foreach (KeyValuePair<Guid, string> kvp in result.Data)
                {
                    cmb_Warehouse.Items.Add(new DictionaryEntry(kvp.Key, kvp.Value));
                }
                cmb_Warehouse.DisplayMember = "value";
                cmb_Warehouse.ValueMember = "key";

                for (int i = 0; i < cmb_Warehouse.Items.Count; i++)
                {
                    if (((DictionaryEntry)cmb_Warehouse.Items[i]).Key.ToString() == ConfigManager.ConfigInfo.WarehouseId)
                    {
                        cmb_Warehouse.SelectedIndex = i;
                        break;
                    }
                }
            }
            //订单类型
            cb_OrderType.Items.Add(new DictionaryEntry("0", "全部"));
            cb_OrderType.Items.Add(new DictionaryEntry("1", "框架订单"));
            cb_OrderType.Items.Add(new DictionaryEntry("2", "非框架订单"));
            cb_OrderType.DisplayMember = "Value";
            cb_OrderType.ValueMember = "Key";
            for (int i = 0; i < cb_OrderType.Items.Count; i++)
            {
                if (int.Parse(((DictionaryEntry)cb_OrderType.Items[i]).Key.ToString()) == ConfigManager.ConfigInfo.OrderType)
                {
                    cb_OrderType.SelectedIndex = i;
                    break;
                }
            }
            //发货单模板
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
            cb_PrintOrderModel.DataSource = templateList;
            cb_PrintOrderModel.DisplayMember = "TemplateName";
            cb_PrintOrderModel.ValueMember = "TemplateID";
            cb_PrintOrderModel.SelectedValue = ConfigManager.ConfigInfo.PrintOrderModel;
        }

        private void tb_GetNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
