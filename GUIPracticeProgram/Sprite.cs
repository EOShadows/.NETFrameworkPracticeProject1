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
    public class Sprite
    {
        private Image image;
        private Rectangle rect;

        public Sprite (Color color, Rectangle rect)
        {
            image = new Bitmap(rect.Width, rect.Height);
           
            using (Graphics gfx = Graphics.FromImage(image))
            using (SolidBrush brush = new SolidBrush(color))
            {
                gfx.FillRectangle(brush, rect);
            }

            this.rect = rect;
        }

        public Sprite (Image image, Rectangle rect)
        {
            this.image = image;
            this.rect = rect;
        }

        public Point Location
        {
            get => rect.Location;
            set => SetLocation(value);
        }

        public void SetLocation(Point point)
        {
            Point before = rect.Location;
            rect.Location = point;
            LocationChanged.Invoke(this, new SpriteLocationChangedArgs(before, rect.Location));
        }

        public int Right
        {
            get => rect.Right;
        }

        public int Left
        {
            get => rect.Left;
        }

        public int Top
        {
            get => rect.Top;
        }

        public int Bottom
        {
            get => rect.Bottom;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, rect);
            graphics.Flush();
        }

        public event EventHandler<SpriteLocationChangedArgs> LocationChanged;
    }

    public class SpriteLocationChangedArgs : EventArgs
    {
        public Point before { get; set; }
        public Point after { get; set; }

        public SpriteLocationChangedArgs(Point before, Point after)
        {
            this.before = before;
            this.after = after;
        }
    }
}
