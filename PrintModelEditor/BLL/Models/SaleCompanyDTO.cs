using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    /// <summary>
    /// 公司模型
    /// </summary>
    public class SaleCompanyDTO
    {
        public Guid SaleCompanyID { get; set; }
        public string SaleCompanyName { get; set; }
        public string SaleCompanyImage { get; set; }
    }
}
