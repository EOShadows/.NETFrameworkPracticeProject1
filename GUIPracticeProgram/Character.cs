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
    /// <summary>
    /// An entity that can move by instruction.
    /// </summary>
    public class Character : Entity
    {
        public const Character.MoveDirection UP = Character.MoveDirection.UP;
        public const Character.MoveDirection DOWN = Character.MoveDirection.DOWN;
        public const Character.MoveDirection RIGHT = Character.MoveDirection.RIGHT;
        public const Character.MoveDirection LEFT = Character.MoveDirection.LEFT;

        public int speed { get; set; }

        public enum MoveDirection
        {
            UP = 0,
            DOWN = 1,
            RIGHT = 2,
            LEFT = 3
        }

        public Character(Control self, string name, int speed, Image image) : base(self, name, image)
        {
            this.self = self;
            this.speed = speed;
            this.name = name;
        }

        /// <summary>
        /// Moves the character in the specified direction.
        /// </summary>
        /// <param name="direction"></param>
        public void Move(MoveDirection direction)
        {
            Point movement = new Point(0, 0);

            switch (direction)
            {
                case MoveDirection.UP:
                    movement = new Point(0, -speed);
                    break;
                case MoveDirection.DOWN:
                    movement = new Point(0, speed);
                    break;
                case MoveDirection.RIGHT:
                    movement = new Point(speed, 0);
                    break;
                case MoveDirection.LEFT:
                    movement = new Point(-speed, 0);
                    break;
            }

            Point newPosition = self.Location.Plus(movement);
            Point positionDiff = newPosition.Minus(self.Location);
            int xDiff = positionDiff.X;
            int yDiff = positionDiff.Y;

            Rect testRect = new Rect(rect.right + xDiff, rect.left + xDiff, rect.top + yDiff, rect.bottom + yDiff);

            if (!WillIntersectAs(testRect))
            {
                self.Location = newPosition;
            }
        }
    }
}
