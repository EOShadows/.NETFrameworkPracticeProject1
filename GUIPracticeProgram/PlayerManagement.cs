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
    public class PlayerManagement
    {
        private static Character player;

        internal static void SetPlayer(Character character)
        {
            player = character;
        }

        internal static void CheckInput(object sender, KeyEventArgs e)
        {
            if (GlobalSettings.WRITE_INPUT)
                System.Diagnostics.Debug.WriteLine("Key down: " + e.KeyCode.ToString());

            if (e.KeyCode == Keys.W) { player.Move(Character.UP); }
            else if (e.KeyCode == Keys.S) { player.Move(Character.DOWN); }
            else if (e.KeyCode == Keys.D) { player.Move(Character.RIGHT); }
            else if (e.KeyCode == Keys.A) { player.Move(Character.LEFT); }
        }
    }
}
