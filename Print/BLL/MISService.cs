
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MISService
    {
        static MISService currentMISService;
        public static MISService CurrentMISService
        {
            get
            {
                if (currentMISService == null)
                    currentMISService = new MISService();
                return currentMISService;
            }
        }
        private MISService()
        {

        }
        /// <summary>
        /// 取得所有公司
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, string> GetAllCompanys()
        {
            return FilialeCache.LogisticsCompany.ToDictionary(ent => ent.ID, ent => ent.Name);
        }

        /// <summary> 获取总公司列表 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, string> GetHeadList()
        {
            return FilialeCache.SaleCompany.OrderBy(ent => ent.OrderIndex).ToDictionary(ent => ent.ID, ent => ent.Name);
        }
    }
}
