using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CommonFunction
    {
        public static int Millimeter2Pix(decimal unitOfMm)
        {
            return (int)Math.Ceiling(unitOfMm / 25.4m * 96.0m);
        }

        public static decimal Pix2Millimeter(int unitOfPix)
        {
            return (decimal)unitOfPix * 25.4m / 96.0m;
        }
    }
}
