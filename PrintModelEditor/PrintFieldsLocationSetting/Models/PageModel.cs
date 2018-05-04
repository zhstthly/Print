using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting.Models
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

        public static PageModel CreateNewPage()
        {
            return new PageModel()
            {
                PageID = Guid.NewGuid(),
                PageName = "",
                Width = 1,
                Height = 1,
                Padding = 0,
                BlankHeight = 0,
                UnSplitBlockHeight = 0
            };
        }
    }
}
