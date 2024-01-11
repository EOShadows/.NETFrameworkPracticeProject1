using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Intersects(Rect other)
        {
            bool flagX1 = other.right > left && other.right < right;
            bool flagX2 = other.left < right && other.left > left;

            bool flagY1 = other.top > top && other.top < bottom;
            bool flagY2 = other.bottom < bottom && other.bottom > top;

            return (flagX1 || flagX2) && (flagY1 || flagY2);
        }

        public static Rect operator+ (Rect lh, Vector2 rh)
        {
            return new Rect(lh.right + rh.x, lh.left + rh.x, lh.top + rh.y, lh.bottom + rh.y);
        }
    }
}
