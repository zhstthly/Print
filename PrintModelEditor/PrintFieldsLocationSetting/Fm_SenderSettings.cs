using BLL;
using BLL.Models;
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

namespace PrintFieldsLocationSetting
{
    public partial class Fm_SenderSettings : Form
    {
        static Fm_SenderSettings currentFmSenderSettings;
        public static Fm_SenderSettings CurrentFmSenderSettings
        {
            get
            {
                if (currentFmSenderSettings == null)
                    currentFmSenderSettings = new Fm_SenderSettings();
                return currentFmSenderSettings;
            }
        }
        private Fm_SenderSettings()
        {
            InitializeComponent();
        }

        private void Fm_SenderSettings_Load(object sender, EventArgs e)
        {
            // 公司设置
            Dictionary<Guid, string> dic = FilialeCache.SaleCompany.ToDictionary(ent => ent.ID, ent => ent.Name);
            List<DisplayValue> displayValueList = new List<DisplayValue>();
            foreach (KeyValuePair<Guid, string> kvp in dic)
            {
                displayValueList.Add(new DisplayValue() { Value = kvp.Key, Display = kvp.Value });
            }
            //此处为了给亚马逊订单提供单独的发件人信息，故本地添加的一条分类（因其非公司其下的一个业务部门）
            displayValueList.Add(new DisplayValue() { Value = new Guid("8B3A077B-049B-4AD5-8BBC-836A01EC315F"), Display = "亚马逊订单" });
            cmb_Company.DisplayMember = "Display";
            cmb_Company.ValueMember = "Value";
            cmb_Company.DataSource = displayValueList;
        }

        public void BindingChanged()
        {
            PrintSenderDTO psDTO = new PrintSenderDTO();
            if (cmb_Company.SelectedValue != null)
            {
                Guid fillialeID = (Guid)cmb_Company.SelectedValue;
                if (cmb_Company.SelectedValue != null)
                {
                    Guid salePlatformID = (Guid)cmb_SalePlatform.SelectedValue;
                    psDTO = PrintDatas.printSenderDTOList.Find(p => p.CompanyID == fillialeID && p.SalePlatformID == salePlatformID);
                }
                if (psDTO == null)
                    psDTO = PrintDatas.printSenderDTOList.Find(p => p.CompanyID == fillialeID && p.SalePlatformID == new Guid());
            }
            if (psDTO == null)
            {
                txt_Sender.Text = string.Empty;
                txt_Signature.Text = string.Empty;
                txt_Phone.Text = string.Empty;
                txt_Mobile.Text = string.Empty;
                txt_Departure.Text = string.Empty;
                txt_WebSite.Text = string.Empty;
                txt_CompanyName.Text = string.Empty;
                txt_Address.Text = string.Empty;
                txt_Header.Text = string.Empty;
                txt_Footer.Text = string.Empty;
                txt_GlassFooter.Text = string.Empty;
            }
            else
            {
                txt_Sender.Text = psDTO.Sender;
                txt_Signature.Text = psDTO.Signature;
                txt_Phone.Text = psDTO.Phone;
                txt_Mobile.Text = psDTO.Mobile;
                txt_Departure.Text = psDTO.Departure;
                txt_WebSite.Text = psDTO.WebSite;
                txt_CompanyName.Text = psDTO.CompanyName;
                txt_Address.Text = psDTO.Address;
                txt_Header.Text = psDTO.Header;
                txt_Footer.Text = psDTO.Footer;
                txt_GlassFooter.Text = psDTO.GlassFooter;

            }
        }

        private void cmb_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Company.SelectedValue == null)
                return;
            Guid fillialeId = (Guid)cmb_Company.SelectedValue;
            var salePlatforms = PlatformCache.AllPlatforms.Where(ent => ent.FilialeId == fillialeId).ToList();
            Dictionary<Guid, string> dic = salePlatforms.ToDictionary(ent => ent.ID, ent => ent.Name);
            List<DisplayValue> displayValueList = new List<DisplayValue>();
            displayValueList.Add(new DisplayValue() { Value = new Guid(), Display = "" });
            //增加对应门店的寄件人信息设置
            var saleShopFiliales = FilialeCache.AllFiliales.Where(ent => ent.ParentId == fillialeId).ToList();
            foreach (KeyValuePair<Guid, string> kvp in dic)
            {
                displayValueList.Add(new DisplayValue() { Value = kvp.Key, Display = kvp.Value });
            }
            foreach (KeyValuePair<Guid, string> kvp in saleShopFiliales.ToDictionary(ent => ent.ID, ent => ent.Name))
            {
                displayValueList.Add(new DisplayValue() { Value = kvp.Key, Display = kvp.Value });
            }
            cmb_SalePlatform.DisplayMember = "Display";
            cmb_SalePlatform.ValueMember = "Value";
            cmb_SalePlatform.DataSource = displayValueList;
        }

        private void cmb_SalePlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingChanged();
        }

        class DisplayValue
        {
            public string Display { get; set; }
            public Guid Value { get; set; }
        }

        private void BT_SenderCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BT_SenderOk_Click(object sender, EventArgs e)
        {
            PrintSenderDTO psFindDTO = PrintDatas.printSenderDTOList.Find(p => p.CompanyID == (Guid)cmb_Company.SelectedValue
                                    && p.SalePlatformID == (Guid)cmb_SalePlatform.SelectedValue);
            if (psFindDTO == null)
            {
                PrintDatas.printSenderDTOList.Add(new PrintSenderDTO()
                {
                    ID = Guid.NewGuid(),
                    CompanyID = (Guid)cmb_Company.SelectedValue,
                    SalePlatformID = (Guid)cmb_SalePlatform.SelectedValue,
                    Sender = txt_Sender.Text,
                    Signature = txt_Signature.Text,
                    Phone = txt_Phone.Text,
                    Mobile = txt_Mobile.Text,
                    Departure = txt_Departure.Text,
                    WebSite = txt_WebSite.Text,
                    CompanyName = txt_CompanyName.Text,
                    Address = txt_Address.Text,
                    Header = txt_Header.Text,
                    Footer = txt_Footer.Text,
                    GlassFooter = txt_GlassFooter.Text
                });
            }
            else
            {
                psFindDTO.Sender = txt_Sender.Text;
                psFindDTO.Signature = txt_Signature.Text;
                psFindDTO.Phone = txt_Phone.Text;
                psFindDTO.Mobile = txt_Mobile.Text;
                psFindDTO.Departure = txt_Departure.Text;
                psFindDTO.WebSite = txt_WebSite.Text;
                psFindDTO.CompanyName = txt_CompanyName.Text;
                psFindDTO.Address = txt_Address.Text;
                psFindDTO.Header = txt_Header.Text;
                psFindDTO.Footer = txt_Footer.Text;
                psFindDTO.GlassFooter = txt_GlassFooter.Text;
            }
        }
    }
}
