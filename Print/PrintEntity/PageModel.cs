using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintEntity
{
    public class PageModel
    {
        public Guid PageID { get; set; }
        public string PageName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Padding { get; set; }
        public int BlankHeight { get; set; }
        public int UnSplitBlockHeight { get; set; }
    }
}
