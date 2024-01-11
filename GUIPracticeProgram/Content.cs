using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUIPracticeProgram
{
    public class Content
    {
        private Dictionary<string, Sprite> sprites;

        public Content(Control viewport)
        {
            sprites = new Dictionary<string, Sprite>();
            Initialize(viewport);
        }

        private void Initialize(Control viewport)
        {
            sprites.Add("playerSprite", new Sprite(
                global::GUIPracticeProgram.Properties.Resources.creepyplushtoy,
                new Rectangle(new Point(0, 0), new Size(60, 60))));
            sprites.Add("obstacle1", new Sprite(
               global::GUIPracticeProgram.Properties.Resources.tileTexture1,
               new Rectangle(new Point(80, 80), new Size(60, 60))));
            sprites.Add("grass", new Sprite(
               Color.GreenYellow,
               new Rectangle(new Point(0, 0), new Size(viewport.Width, viewport.Height))));
        }

        public Sprite this[string i]
        {
            get { return sprites[i]; }
        }
    }
}
