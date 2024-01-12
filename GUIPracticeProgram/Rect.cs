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
    public class Rect
    {
        /// <summary>
        /// The position of the right side of the rectangle on the x axis.
        /// </summary>
        public int right { get; set; }
        /// <summary>
        /// The position of the left side of the rectangle on the x axis.
        /// </summary>
        public int left { get; set; }
        /// <summary>
        /// The position of the top side of the rectangle on the y axis.
        /// </summary>
        public int top { get; set; }
        /// <summary>
        /// The position of the bottom side of the rectangle on the y axis.
        /// </summary>
        public int bottom { get; set; }

        /// <summary>
        /// The position of the top left corner of the rectangle.
        /// </summary>
        public Vector2 upperLeft;

        /// <summary>
        /// The position of the center of the rectangle.
        /// </summary>
        public Vector2 center;

        public Rect(int right, int left, int top, int bottom)
        {
            this.right = right;
            this.left = left;
            this.top = top;
            this.bottom = bottom;

            upperLeft = new Vector2(left, top);
            center = new Vector2(left + ((right - left) / 2), top + ((bottom - top) / 2));
        }

        public int GetWidth()
        {
            return right - left;
        }

        public int GetHeight()
        {
            return bottom - top;
        }

        public bool Intersects(Rect other)
        {
            return Intersects(this, other) || Intersects(other, this);
        }

        private bool Intersects(Rect lh, Rect rh)
        {
            bool flagX1 = rh.right >= lh.left && rh.right <= lh.right;
            bool flagX2 = rh.left <= lh.right && rh.left >= lh.left;

            bool flagY1 = rh.top >= lh.top && rh.top <= lh.bottom;
            bool flagY2 = rh.bottom <= lh.bottom && rh.bottom >= lh.top;

            return (flagX1 || flagX2) && (flagY1 || flagY2);
        }

        public static Rect operator+ (Rect lh, Vector2 rh)
        {
            return new Rect(lh.right + rh.x, lh.left + rh.x, lh.top + rh.y, lh.bottom + rh.y);
        }

        /// <summary>
        /// Draw to the screen
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            if (!GlobalSettings.DRAW_RECT)
                return;

            Pen pen = new Pen(GlobalSettings.RECT_COLOR, GlobalSettings.RECT_LINE_WIDTH);

            var bottomRight =    new Point(upperLeft.x + GetWidth(), upperLeft.y + GetHeight());
            var upperRight  =    new Point(upperLeft.x + GetWidth(), upperLeft.y);
            var bottomLeft  =    new Point(upperLeft.x, upperLeft.y + GetHeight());

            e.Graphics.DrawLine(pen, upperLeft.AsPoint(), upperRight); // Draw top line
            e.Graphics.DrawLine(pen, upperRight, bottomRight); // Draw right line
            e.Graphics.DrawLine(pen, upperLeft.AsPoint(), bottomLeft); // Draw top line
            e.Graphics.DrawLine(pen, bottomRight, bottomLeft); // Draw top line

            pen.Dispose();
        }

        public override string ToString()
        {
            return "Rect() top=" + top + " bottom=" + bottom + " right=" + right + " left=" + left;
        }
    }
}
