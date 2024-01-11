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
    public class Entity
    {
        protected static List<Entity> all;

        public string name { get; set; }
        public Control self { get; set; }
        protected Rect rect;
        
        public Entity(Control self, string name)
        {
            all = new List<Entity>();

            this.self = self;
            this.name = name;
            rect = new Rect(self.Right, self.Left, self.Top, self.Bottom);
            self.LocationChanged += new EventHandler(OnLocationChanged);
            all.Add(this);
        }

        /// <summary>
        /// Does the given point intersect with an entity?
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool IntersectsAnEntity(Point point)
        {
            foreach (Entity obj in all)
            {
                if (obj.Intersects(point))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tests the given rect to see if it will intersect with another Entity 
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public bool WillIntersectAs(Rect rect)
        {
            foreach (Entity obj in all)
            {
                if (obj.name != name && obj.rect.Intersects(rect))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Does this Entity intersect with another?
        /// </summary>
        /// <returns></returns>
        public bool IntersectsAnother()
        {
            foreach (Entity obj in all)
            {
                if (obj.Intersects(this))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Does this entity inersect with the given Entity?
        /// </summary>
        /// <param name="other"> The other Entity </param>
        /// <returns></returns>
        public bool Intersects(Entity other)
        {
            return other.rect.Intersects(rect);
        }

        /// <summary>
        /// Does this Entity intersect with the given point
        /// </summary>
        /// <param name="point">The point to check for an intersection with this Entity.</param>
        /// <returns></returns>
        public bool Intersects(Point point)
        {
            bool condition1 = point.X >= self.Left && point.X <= self.Right;
            bool condition2 = point.Y <= self.Bottom && point.Y >= self.Top;

            return (condition1 && condition2);
        }

        private void OnLocationChanged(object obj, EventArgs e)
        {
            UpdateRect();
        }

        private void UpdateRect()
        {
            Rect oldRect = rect;
            int x = self.Location.X - oldRect.upperLeft.x;
            int y = self.Location.Y - oldRect.upperLeft.y;


            rect = new Rect(oldRect.right + x, oldRect.left + x, oldRect.top + y, oldRect.bottom + y);
        }

        /// <summary>
        /// Changes an entity to have a different rect than its default one.
        /// </summary>
        /// <param name="entity">The new entity</param>
        /// <param name="rect">The custom rectangle</param>
        /// <returns> The new entity with the custom rect</returns>
        public static Entity CreateWithCustomRect(Entity entity, Rect rect)
        {
            entity.rect = rect + entity.rect.upperLeft;
            return entity;
        }

        /// <summary>
        /// Changes an entity to have a rect that is a modified version of the default.
        /// </summary>
        /// <param name="entity">       The new entity</param>
        /// <param name="percChange">   The percent differance from the original on x and y axis starting from the sides said by changeFrom.
        ///                             Restrictions:   0 <= x <= 100
        ///                                             0 <= y <= 100 </param>
        /// <param name="changeFrom">   The sides to apply the percentage from.  For instance, if changeFrom were (1,1) then the percentage of 
        ///                             0 to 100 is right to left, bottom to top.
        ///                             If changeFrom were (0,1) then it is left to right, bottom to up.
        ///                             If changeFrom were (0,0), then it is from left to right, top to bottom.
        ///                             If changeFrom were (1,0), then it is from right to left, top to bottom.
        ///                             Restrictions:   x = 0 or 1
        ///                                             y = 0 or 1 </param>
        /// 
        /// <returns>The new entity with the modified rect</returns>
        public static Entity CreateWithModifiedRect(Entity entity, Vector2 percChange, Vector2 changeFrom)
        {
            if ((changeFrom.x != 0 && changeFrom.x != 1) || (changeFrom.y != 0 && changeFrom.y != 1))
            {
                throw new ArgumentException("Argument \"changeFrom\" is invalid.  Expected x = 0 or 1, y = 0 or 1, recieved: x=" + changeFrom.x + " y=" + changeFrom.y);
            }

            if (percChange < 0 || percChange > 100)
            {
                throw new ArgumentException("Argument \"percChange\" is invalid.  Expected 0 <= x <= 100, 0 <= y <= 100, recieved: x=" + percChange.x + " y=" + percChange.y);
            }

            int newRight = entity.rect.right;
            int newLeft = entity.rect.left;
            int newTop = entity.rect.top;
            int newBottom = entity.rect.bottom;

            int percX = (int)((entity.rect.right - entity.rect.left) * (percChange.x / 100));
            int percY = (int)((entity.rect.bottom - entity.rect.top) * (percChange.y / 100));

            if (changeFrom.x == 0 && percChange.x != 100)
            {
                newRight = entity.rect.left + percX;
            }
            else if (changeFrom.x == 1 && percChange.x != 100)
            {
                newLeft = entity.rect.right - percX;
            }

            if (changeFrom.y == 0 && percChange.y != 100)
            {
                newBottom = entity.rect.top + percY;
            }
            else if (changeFrom.y == 1 && percChange.y != 100)
            {
                newTop = entity.rect.bottom - percY;
            }

            System.Diagnostics.Debug.WriteLine(entity.rect.right + "/" + newRight + " " + 
                entity.rect.left + "/" + newLeft + " " + 
                entity.rect.top + "/" + newTop + " " +
                entity.rect.bottom + "/" + newBottom);
            Rect newRect = new Rect(newRight, newLeft, newTop, newBottom);
            entity.rect = newRect;        
            
            return entity;
        }
    }
}
