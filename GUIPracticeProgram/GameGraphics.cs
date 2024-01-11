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
    /// Handles the game graphics.
    /// </summary>
    public class GameGraphics
    {
        /// <summary>
        /// The image of the viewport
        /// </summary>
        private Image viewportImage;

        /// <summary>
        /// The graphics object used to draw to the viewport image before it 
        /// is drawn to the screen with the viewport control objct.
        /// </summary>
        private Graphics graphicsBuffer;

        /// <summary>
        /// Initialize the game graphics to begin drawing to the given viewport
        /// control object whenever it is invalidated.
        /// </summary>
        /// <param name="viewport"> The control object to display the graphics
        ///                         on the screeen. </param>
        internal GameGraphics(Control viewport)
        {
            viewportImage = new Bitmap(viewport.Width, viewport.Height);
            graphicsBuffer = Graphics.FromImage(viewportImage);
            viewport.Paint += new PaintEventHandler(UpdateGraphics);
        }

        /// <summary>
        /// Called when the viewport control object is invalidated.
        /// Updates what is drawn on the screen.
        /// </summary>
        private void UpdateGraphics(object obj, PaintEventArgs e)
        {
            PrepareViewport();
            DrawViewport(e.Graphics);
        }


        /// <summary>
        /// Draws everything to the graphics buffer of the viewport.
        /// </summary>
        private void PrepareViewport()
        {
            Entity.all.Sort();

            foreach (Entity entity in Entity.all)
            {
                entity.DrawSprite(graphicsBuffer);
            }
        }

        /// <summary>
        /// Draws the viewport image to the viewport control object.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawViewport(Graphics graphics)
        {
            graphics.Clear(Color.Black);
            graphics.DrawImage(viewportImage, new Point(0, 0));
        }
    }
}
