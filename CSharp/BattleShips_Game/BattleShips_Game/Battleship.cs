using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips_Game
{
    class Battleship : Ship
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

        
        public Battleship():base()
        {
            Random random = new Random();
            isHorisontal = GenerateHorisontality(random);
            x = GenerateX(random, isHorisontal);
            y = GenerateY(random, isHorisontal);
            isAlive = true;
            parts = new List<ShipPart>();
            GenerateShipParts();
        }

        public override int GenerateX(Random rand, bool isHorisontal)
        {
            if (isHorisontal == true)
            {
                int currentX = 0;

                while (true)
                {
                    currentX = rand.Next(0, 10);

                    if (currentX <= 5)
                    {
                        break;
                    }
                }

                return currentX;
            }

            else
            {
                return rand.Next(0, 10);
            }
        }

        public override int GenerateY(Random rand, bool isHorisontal)
        {
            if (isHorisontal == true)
            {
                return rand.Next(0, 10);
            }
            else
            {
                int currentY = 0;

                while (true)
                {
                    currentY = rand.Next(0, 10);

                    if (currentY <= 5)
                    {
                        break;
                    }
                }

                return currentY;
            }
        }

        public override bool GenerateHorisontality(Random rand)
        {
            if (rand.Next(0, 2) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void SinkShip()
        {
            this.IsAlive = false;
        }

        private void GenerateShipParts()
        {
            if (isHorisontal == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    ShipPart prt = new ShipPart(x + i, y);
                    this.parts.Add(prt);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    ShipPart prt = new ShipPart(x, y + i);
                    this.parts.Add(prt);
                }
            }
        }
    }
}
