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
        private bool isAlive;

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
        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
            set { }
        }

        public ShipPart(int xValue, int yValue)
        {
            x = xValue;
            y = yValue;
            isAlive = true;
        }

        public void DestroyPart()
        {
            this.isAlive = false;
        }
    }
}
