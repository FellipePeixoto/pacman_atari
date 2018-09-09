using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman_Atari
{
    class Enum
    {
        public enum Direction
        {
            up, right, down, left
        }

        public enum ObjectType 
        { 
            alive, dot, fruit, block, none
        }
    }
}
