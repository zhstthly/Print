using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class OrderPrintDataDTO
    {
        /// <summary>出货单号
        /// </summary>
        public string OutGoodsBillNo { get; set; }

        /// <summary>下货单号
        /// </summary>
        public string DownGoodsBillNo { get; set; }

        /// <summary>订单号(合并发货,多个逗号分开)
        /// </summary>
        public string OrderNos { get; set; }

        /// <summary>下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>收货人
        /// </summary>
        public string Consignee { get; set; }

        /// <summary>手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>电话号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>收货地址
        /// </summary>
        public string Direction { get; set; }

        /// <summary>应付款
        /// </summary>
        public decimal RealTotalPrice { get; set; }

        /// <summary>支付方式
        /// </summary>
        public byte PayMode { get; set; }

        /// <summary>快递名称
        /// </summary>
        public string ExpressName { get; set; }

        /// <summary>快递ID
        /// </summary>
        public Guid ExpressId { get; set; }

        /// <summary>快递号
        /// </summary>
        public string ExpressNo { get; set; }

        /// <summary>销售公司ID
        /// </summary>
        public Guid SaleFilialeId { get; set; }

        /// <summary>销售平台ID
        /// </summary>
        public Guid SalePlatformId { get; set; }

        /// <summary>是否有发票
        /// </summary>
        public bool HasInvoice { get; set; }

        /// <summary>是否含加工单
        /// </summary>
        public bool IsContainProcessOrder { get; set; }

        /// <summary>箱号
        /// </summary>
        public string BoxNo { get; set; }

        public string TotalBillNo { get; set; }

        /// <summary>临时存储商品总数量
        /// </summary>
        public int TempTotalQuantity { get; set; }

        public string DateNow
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        public PrintSenderDTO SenderInfo { get; set; }
        public DimensionalCodeDTO DimensionalCodeDto { get; set; }

        /// <summary>订单明细
        /// </summary>
        public List<OrderDetailPrintDataDTO> OrderDetailPrintDataDtos { get; set; }
    }

    public class OrderDetailPrintDataDTO
    {
        public Guid GoodsId { get; set; }

        public Guid RealGoodsId { get; set; }

        /// <summary>货位号
        /// </summary>
        public string BinNo { get; set; }

        /// <summary>商品名称
        /// </summary>
        public string GoodName { get; set; }

        /// <summary>规格
        /// </summary>
        public string Sku { get; set; }

        /// <summary>生产厂家
        /// </summary>
        public string ProductionCompany { get; set; }

        /// <summary>批号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>数量
        /// </summary>
        public int Quantity { get; set; }

        public bool IsProcessOrder { get; set; }
    }
}
