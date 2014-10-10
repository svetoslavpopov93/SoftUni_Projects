using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips_Game
{
    abstract class Ship
    {
        private int x;
        private int y;
        private bool isHorisontal;
        private bool isAlive;

        public Ship()
        {
        }

        public abstract int GenerateX(Random rand, bool isHorisontal);
        public abstract int GenerateY(Random rand, bool isHorisontal);
        public abstract bool GenerateHorisontality(Random rand);
        public abstract void GenerateShipParts();
        public abstract void SinkShip();
    }
}
