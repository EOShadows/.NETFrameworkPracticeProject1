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
    /// A Character that can do its own thing, independant from input from the player.
    /// Could also be interacted with.
    /// </summary>
    public class NPC : Character
    {
        private MoveDirection moveDirection;

        public NPC(Control self, string name, int speed) : base(self, name, speed) { }

        public void Move() { Move(moveDirection); }
    }
}
