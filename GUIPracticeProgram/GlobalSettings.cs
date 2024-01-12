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
    /// A collection of constant properties to control behaviour throughout
    /// the code.
    /// </summary>
    public class GlobalSettings
    {
        // DEBUGGING ////////////////////////////////////////////////

        /* RECTANGLE DRAWING ------------------------------------- */
        public static bool DRAW_RECT        { get => false; }
        public static Color RECT_COLOR      { get => Color.Red; }
        public static int RECT_LINE_WIDTH   { get => 2; }
        /* ------------------------------------------------------- */

        /* DEBUG CONSOLE MESSAGES -------------------------------- */
        public static bool WRITE_INPUT      { get => false; }
        /* ------------------------------------------------------- */

        /////////////////////////////////////////////////////////////
    }
}
