using BLL;
using DataEntity;
using Infrastructure;
using Infrastructure.Models;
using PrintServer;
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
    public partial class Fm_ManualPrint : Form
    {
        public Fm_ManualPrint()
        {
            InitializeComponent();
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_KeyWord.Text))
            {
                MessageBox.Show(this, @"请输入出货单号！", @"注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgv_Order.Rows.Clear();

            var result = WMSService.CurrentWMSService.GetOrderPrintShowData(new Guid(ConfigManager.ConfigInfo.WarehouseId), 
                new Guid(ConfigManager.ConfigInfo.InvoiceFilialeId), tb_KeyWord.Text.Trim());
            if (result.IsSuccess)
            {
                foreach (var item in result.Data)
                {
                    this.dgv_Order.Rows.Add(false, item.OutGoodsBillNo, item.DownGoodsBillNo, item.OrderNos, item.OrderTime, 
                        item.DownGoodsBillState, item.OutGoodsBillState, item.Consignee, item.Mobile, item.ExpressName, item.Direction, item.ExpressId);
                }
            }
            else
            {
                MessageBox.Show(this, result.Msg, @"注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void Fm_ManualPrint_Load(object sender, EventArgs e)
        {
            var cbColumn = new DataGridViewCheckBoxColumn();
            dgv_Order.Columns.Add(cbColumn);
            dgv_Order.Columns[0].HeaderText = @"选择";
            dgv_Order.Columns[0].ReadOnly = false;
            dgv_Order.Columns[0].Width = 40;

            dgv_Order.Columns.Add("OutGoodsBillNo", "出货单号");
            dgv_Order.Columns[1].Width = 100;
            dgv_Order.Columns[1].ReadOnly = true;

            dgv_Order.Columns.Add("DownGoodsBillNo", "下货单号");
            dgv_Order.Columns[2].Width = 100;
            dgv_Order.Columns[2].ReadOnly = true;

            dgv_Order.Columns.Add("OrderNos", "订单号");
            dgv_Order.Columns[3].Width = 150;
            dgv_Order.Columns[3].ReadOnly = true;

            dgv_Order.Columns.Add("OrderTime", "下单时间");
            dgv_Order.Columns[4].Width = 120;
            dgv_Order.Columns[4].ReadOnly = true;

            dgv_Order.Columns.Add("DownGoodsState", "下货单状态");
            dgv_Order.Columns[5].Width = 90;
            dgv_Order.Columns[5].ReadOnly = true;

            dgv_Order.Columns.Add("OutGoodsBillState", "出货单状态");
            dgv_Order.Columns[6].Width = 90;
            dgv_Order.Columns[6].ReadOnly = true;

            dgv_Order.Columns.Add("Consignee", "收货人");
            dgv_Order.Columns[7].Width = 80;
            dgv_Order.Columns[7].ReadOnly = true;

            dgv_Order.Columns.Add("Mobile", "手机");
            dgv_Order.Columns[8].Width = 80;
            dgv_Order.Columns[8].ReadOnly = true;

            dgv_Order.Columns.Add("ExpressName", "快递公司");
            dgv_Order.Columns[9].Width = 200;
            dgv_Order.Columns[9].ReadOnly = true;

            dgv_Order.Columns.Add("Direction", "收件地址");
            dgv_Order.Columns[10].Width = 300;
            dgv_Order.Columns[10].ReadOnly = true;

            dgv_Order.Columns.Add("ExpressId", "快递ID");
            dgv_Order.Columns[11].Visible = false;

            dgv_Order.AllowUserToAddRows = false;

            // 打印机列表
            var ordPrtList = PrinterSystemConfig.GetPrinterList();
            cmb_OrdPrinter.DataSource = ordPrtList;

            //快递打印机
            var expPrtList = PrinterSystemConfig.GetPrinterList();
            cmb_ExpPrinter.DataSource = expPrtList;

            // 快递模版
            var tmplDic = DataManager.TemplateM.Select(t => new { TemplateID = t.ModelID, TemplateName = t.ModelName }).ToList();
            tmplDic.Insert(0, new { TemplateID = new Guid(), TemplateName = "" });
            cmb_TmplLst.DataSource = tmplDic;
            cmb_TmplLst.DisplayMember = "TemplateName";
            cmb_TmplLst.ValueMember = "TemplateID";
        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_OrdPrinter.Text))
            {
                MessageBox.Show(this, @"请选择打印机！", @"注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (WMSService.WMSOrderNos != null && WMSService.WMSOrderNos.Values.Count > 0)
            {
                MessageBox.Show(this, @"打印正在进行，请等待打印完成之后再进行此操作！", @"注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var downGoodsBillNo = string.Empty;
            var downGoodsBillState = string.Empty;
            foreach (var row in dgv_Order.Rows.Cast<DataGridViewRow>().Where(row => null != row.Cells[0].Value && ((bool)row.Cells[0].Value)))
            {
                downGoodsBillNo = row.Cells[2].Value.ToString();
                downGoodsBillState = row.Cells[5].Value.ToString();
                break;
            }
            if (string.IsNullOrWhiteSpace(downGoodsBillNo))
            {
                MessageBox.Show(this, @"请选择要打印的下货单！", @"注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var result = WMSService.CurrentWMSService.GetPrintOrderBill(new Guid(ConfigManager.ConfigInfo.WarehouseId),
                new Guid(ConfigManager.ConfigInfo.InvoiceFilialeId), downGoodsBillNo);
            if (result.IsSuccess)
            {
                var printType = downGoodsBillState == "待下货" ? PrintType.Manual : PrintType.Again;
                try
                {
                    PrinterManager.PrintOrder(ConfigManager.ConfigInfo.PrintOrderModel, result.Data,
                        cmb_OrdPrinter.Text, printType, YesOrNo.No, PrintAbout.Order);
                }
                catch (Exception ex)
                {
                    WMSService.NoPrintedResetReaderId(new List<string> { downGoodsBillNo });
                    MessageBox.Show(ex.Message, @"提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, result.Msg, @"注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_PrintExpress_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_ExpPrinter.Text) || string.IsNullOrEmpty(cmb_TmplLst.Text))
            {
                MessageBox.Show(this, @"打印快递单时请选择<快递打印机>和<快递单模版>！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (WMSService.WMSOrderNos != null && WMSService.WMSOrderNos.Values.Count > 0)
            {
                MessageBox.Show(this, @"打印正在进行，请等待打印完成之后再进行此操作！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var downGoodsBillNo = string.Empty;
            var downGoodsBillState = string.Empty;
            foreach (var row in dgv_Order.Rows.Cast<DataGridViewRow>().Where(row => null != row.Cells[0].Value && ((bool)row.Cells[0].Value)))
            {
                downGoodsBillNo = row.Cells[2].Value.ToString();
                downGoodsBillState = row.Cells[5].Value.ToString();
                break;
            }
            if (string.IsNullOrWhiteSpace(downGoodsBillNo))
            {
                MessageBox.Show(this, @"请选择要打印的订单！", @"注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //取得订单 
            var result = WMSService.CurrentWMSService.GetPrintOrderBill(new Guid(ConfigManager.ConfigInfo.WarehouseId),
                new Guid(ConfigManager.ConfigInfo.InvoiceFilialeId), downGoodsBillNo);
            if (result.IsSuccess)
            {
                var printType = downGoodsBillState == "待下货" ? PrintType.Manual : PrintType.Again;
                try
                {
                    PrinterManager.PrintOrder(new Guid(cmb_TmplLst.SelectedValue.ToString()), result.Data, cmb_ExpPrinter.Text, printType, YesOrNo.No, PrintAbout.Express);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, @"提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
