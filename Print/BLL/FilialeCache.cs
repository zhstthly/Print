using Framework.WCF;
using MIS.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 公司
    /// </summary>
    public class FilialeCache
    {
        /// <summary> 所有公司(包括门店)基本信息
        /// </summary>
        public static IEnumerable<FilialeInfo> AllFiliales
        {
            get
            {
                using (var channel = CreateMISWcfClient())
                {
                    var tempAllFiliales = channel.Instance.GetAllFiliale().Where(ent => ent.IsActive).ToList();
                    foreach (var item in tempAllFiliales)
                    {
                        if (item.IsActive)
                        {
                            yield return new FilialeInfo
                            {
                                ID = item.ID,
                                Address = item.Address,
                                Code = item.Code,
                                Description = item.Description,
                                Name = item.Name,
                                RealName = item.RealName,
                                ParentId = item.ParentId,
                                Rank = item.Rank,
                                FilialeTypes = item.FilialeTypes,
                                ShopJoinType = item.ShopJoinType,
                                TaxNumber = item.TaxNumber,
                                RegisterAddress = item.RegisterAddress,
                                IsActive = item.IsActive
                            };
                        }
                    }
                }
            }
        }



        internal static ServiceClient<MIS.Service.Contract.IService> CreateMISWcfClient()
        {
            return new ServiceClient<MIS.Service.Contract.IService>("Group.MIS");
        }

        /// <summary>获取Type=1的公司集合，销售公司
        /// </summary>
        public static IList<FilialeInfo> LogisticsCompany
        {
            get { return AllFiliales.Where(ent => ent.FilialeTypes.Contains((int)MIS.Enum.FilialeType.LogisticsCompany)).OrderBy(ent => ent.OrderIndex).ToList(); }
        }

        /// <summary>获取Type=1的公司集合，销售公司
        /// </summary>
        public static IList<FilialeInfo> SaleCompany
        {

            get { return AllFiliales.Where(ent => ent.FilialeTypes.Contains((int)MIS.Enum.FilialeType.SaleCompany)).OrderBy(ent => ent.OrderIndex).ToList(); }
        }

        /// <summary>获取Type=2的公司集合，门店。并且是非顶级公司（具体销售店面）
        /// </summary>
        public static IList<FilialeInfo> ShopFiliales
        {
            get { return AllFiliales.Where(ent => ent.FilialeTypes.Contains((int)MIS.Enum.FilialeType.EntityShop)).OrderBy(ent => ent.OrderIndex).ToList(); }
        }
    }
}
