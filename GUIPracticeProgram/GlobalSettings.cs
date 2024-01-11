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
    public class GlobalSettings
    {
        private static bool DRAW_RECT = false;
        private static Color RECT_COLOR = Color.Red;
        private static int RECT_LINE_WIDTH = 8;

        public static bool GetDrawRect()
        {
            return DRAW_RECT;
        }

        public static Color GetRectColor()
        {
            return RECT_COLOR;
        }

        public static int GetRectLineWidth()
        {
            return RECT_LINE_WIDTH;
        }
    }
}
