using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GUIPracticeProgram
{
    public class Vector2
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vector2 (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator + (Vector2 lh, Vector2 rh)
        {
            Vector2 newVector = new Vector2(lh.x + rh.x, lh.y + rh.y);
            return newVector;
        }

        public static Vector2 operator +(Vector2 lh, int rh)
        {
            Vector2 newVector = new Vector2(lh.x + rh, lh.y + rh);
            return newVector;
        }

        public static Vector2 operator -(Vector2 lh, Vector2 rh)
        {
            Vector2 newVector = new Vector2(lh.x - rh.x, lh.y - rh.y);
            return newVector;
        }

        public static Vector2 operator -(Vector2 lh, int rh)
        {
            Vector2 newVector = new Vector2(lh.x - rh, lh.y - rh);
            return newVector;
        }

        public static Vector2 operator *(Vector2 lh, Vector2 rh)
        {
            Vector2 newVector = new Vector2(lh.x * rh.x, lh.y * rh.y);
            return newVector;
        }

        public static Vector2 operator *(Vector2 lh, int rh)
        {
            Vector2 newVector = new Vector2(lh.x * rh, lh.y * rh);
            return newVector;
        }

        /// <summary>
        /// Checks if lh.x or lh.y is less than rh
        /// </summary>
        /// <param name="lh"></param>
        /// <param name="rh"></param>
        /// <returns>boolean indicating if lh.x or lh.y is less than rh</returns>
        public static bool operator <(Vector2 lh, int rh)
        {
            return lh.x < rh || lh.y < rh;
        }
        /// <summary>
        /// Checks if lh.x or lh.y is larger than rh
        /// </summary>
        /// <param name="lh"></param>
        /// <param name="rh"></param>
        /// <returns>boolean indicating if lh.x or lh.y is greater than rh</returns>
        public static bool operator >(Vector2 lh, int rh)
        {
            return lh.x > rh || lh.y > rh;
        }

        /// <summary>
        /// Checks if x and y of lh are less than their counterparts in rh
        /// In other words, is the set [rh.x, rh.y] the maximum set?
        /// </summary>
        /// <param name="lh"></param>
        /// <param name="rh"></param>
        /// <returns></returns>
        public static bool operator <(Vector2 lh, Vector2 rh)
        {
            return lh.x < rh.x && lh.y < rh.y;
        }
        /// <summary>
        /// Checks if x and y of lh are greater than their counterparts in rh
        /// In other words, is the set [lh.x, lh.y] the maximum set?
        /// </summary>
        /// <param name="lh"></param>
        /// <param name="rh"></param>
        /// <returns></returns>
        public static bool operator >(Vector2 lh, Vector2 rh)
        {
            return lh.x > rh.x && lh.y > rh.y;
        }

        public int Dot(Vector2 rh)
        {
            return (x * rh.x) + (y * rh.y);
        }

        public Point AsPoint()
        {
            return new Point(x, y);
        }

        public override string ToString()
        {
            return "(x=" + x + ", y=" + y + ")";
        }
    }
}
