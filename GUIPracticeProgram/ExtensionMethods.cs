using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIPracticeProgram
{
    public static class ExtensionMethods
    {
        public static Point Plus(this Point point, Point otherPoint)
        {
            int x = point.X + otherPoint.X;
            int y = point.Y + otherPoint.Y;

            return new Point(x, y);
        }

        public static Point Minus(this Point point, Point otherPoint)
        {
            int x = point.X - otherPoint.X;
            int y = point.Y - otherPoint.Y;

            return new Point(x, y);
        }

        public static Vector2 AsVector2(this Point point)
        {
            return new Vector2(point.X, point.Y);
        }
    }
}
