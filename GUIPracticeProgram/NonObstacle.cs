using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIPracticeProgram
{
    public class NonObstacle : Entity
    {
        public NonObstacle(Sprite self, string name) : base(self, name)
        {
            layer = -1;
        }
    }
}
