using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting
{
    public class PaintConvert
    {
        public static int Millimeter2Pix(decimal unitOfMm)
        {
            return (int)Math.Ceiling(unitOfMm / 25.4m * 96.0m);
        }

        public static decimal Pix2Millimeter(int unitOfPix)
        {
            return (decimal)unitOfPix * 25.4m / 96.0m;
        }

        public static Point PageToView(Point pageL, Point pageP)
        {
            return new Point(pageL.X + pageP.X, pageL.Y + pageP.Y);
        }

        public static Point ViewToPage(Point pageL, Point viewP)
        {
            return new Point(viewP.X - pageL.X, viewP.Y - pageL.Y);
        }
    }
}
