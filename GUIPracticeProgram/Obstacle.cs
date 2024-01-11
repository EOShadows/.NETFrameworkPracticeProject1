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
    /// An immovable entity
    /// </summary>
    public class Obstacle : Entity
    {
        public Obstacle(Sprite self, string name, int layer = 0) : base(self, name, layer) { }
    }
}
