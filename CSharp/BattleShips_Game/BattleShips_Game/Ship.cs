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
        private List<ShipPart> parts;

        public int X
        {
            get
            {
                return this.x;
            }

            private set
            {
                this.x = value;
            }
        }
        public int Y
        {
            get
            {
                return this.y;
            }

            private set
            {
                this.y = value;
            }
        }
        public bool IsHorisontal
        {
            get
            {
                return this.isHorisontal;
            }
            set { }
        }
        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
            private set { }
        }
        public List<ShipPart> Parts
        {
            get
            {
                return this.parts;
            }
            set { }
        }

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
