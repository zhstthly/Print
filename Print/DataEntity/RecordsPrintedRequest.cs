using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class RecordsPrintedRequest
    {
        /// <summary>总单号
        /// </summary>
        public string TotalBillNo { get; set; }

        /// <summary>下货单与其对应的箱号
        /// </summary>
        public Dictionary<string, string> DownGoodsBillNoCartonNoDic { get; set; }
    }
}
