using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips_Game
{
    class ShipPart
    {
        private int x;
        private int y;

        public int X
        {
            get
            {
                return this.x;
            }
            set { }
        }
        public int Y
        {
            get
            {
                return this.y;
            }
            set { }
        }

        public ShipPart(int xValue, int yValue)
        {
            x = xValue;
            y = yValue;
        }
    }
}
