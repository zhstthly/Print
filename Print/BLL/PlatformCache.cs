using Framework.WCF;
using MIS.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PlatformCache
    {
        /// <summary>所有销售平台
        /// </summary>
        public static IEnumerable<SalePlatformInfo> AllPlatforms
        {
            get
            {
                using (var client = new ServiceClient<MIS.Service.Contract.IService>("Group.MIS"))
                {
                    var tempAllPlatforms = client.Instance.GetAllSalePlatform();
                    foreach (var item in tempAllPlatforms)
                    {
                        if (item.IsActive)
                        {
                            yield return new SalePlatformInfo
                            {
                                FilialeId = item.FilialeId,
                                ID = item.ID,
                                IsActive = item.IsActive,
                                Name = item.Name,
                                Url = item.Url,
                                ExternalName = item.ExternalName
                            };
                        }
                    }
                }
            }
        }
    }
}
