using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting
{
    public static class DrawingExtends
    {
        public static Point MultiplyPercentage(this Point point, decimal percentage)
        {
            return new Point((int)((decimal)point.X * percentage), (int)((decimal)point.Y * percentage));
        }

        public static Point DividePercentage(this Point point, decimal percentage)
        {
            return new Point((int)((decimal)point.X / percentage), (int)((decimal)point.Y / percentage));
        }

        public static Point AddOffset(this Point point, Point offset)
        {
            return new Point(point.X + offset.X, point.Y + offset.Y);
        }
    }
}
