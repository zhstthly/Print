using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public enum PrintType
    {
        /// <summary>
        /// 自动打印
        /// </summary>
        Auto = 0,
        /// <summary>
        /// 再次打印
        /// </summary>
        Again = 1,
        /// <summary>
        /// 手动打印
        /// </summary>
        Manual = 2
    }

    public enum YesOrNo
    {
        All = -1,
        No = 0,
        Yes = 1
    }

    public enum PrintAbout
    {
        Order,
        Express
    }
}
