using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips_Game
{
    class Destroyer : Ship
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
            set { }
        }
        public List<ShipPart> Parts
        {
            get
            {
                return this.parts;
            }
            set { }
        }

        public Destroyer()
        {
            Random random = new Random();
            isHorisontal = GenerateHorisontality(random);
            x = GenerateX(random, isHorisontal);
            y = GenerateY(random, isHorisontal);
            isAlive = true;
            parts = new List<ShipPart>();
            GenerateShipParts();
        }

        /// <summary>
        /// Generates the value of X coordinate index, depending on the direction of the ship and the placement on the game field
        /// </summary>
        /// <param name="rand">The Random variable is declared in the constructor once, and then given as a parameter, to avoid code repeat</param>
        /// <param name="isHorisontal"></param>
        /// <returns>Returns the X index</returns>
        public override int GenerateX(Random rand, bool isHorisontal)
        {
            if (isHorisontal == true)
            {
                int currentX = rand.Next(0, 7);

                return currentX;
            }

            else
            {
                return rand.Next(0, 7);
            }
        }

        /// <summary>
        /// Generates the value of Y coordinate index, depending on the direction of the ship and the placement on the game field
        /// </summary>
        /// <param name="rand">The Random variable is declared in the constructor once, and then given as a parameter, to avoid code repeat</param>
        /// <param name="isHorisontal"></param>
        /// <returns>Returns the Y index</returns>
        public override int GenerateY(Random rand, bool isHorisontal)
        {
            if (isHorisontal == true)
            {
                return rand.Next(0, 7);
            }
            else
            {
                int currentY = rand.Next(0, 7);

                return currentY;
            }
        }

        /// <summary>
        /// Generates the direction of the ship
        /// </summary>
        /// <param name="rand"></param>
        /// <returns>Returns a bool value to determine if the ship will be horisontal or not</returns>
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

        public override void GenerateShipParts()
        {
            if (isHorisontal == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    ShipPart prt = new ShipPart(x + i, y);
                    this.parts.Add(prt);
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    ShipPart prt = new ShipPart(x, y + i);
                    this.parts.Add(prt);
                }
            }
        }

        public override void SinkShip()
        {
            this.isAlive = false;
        }
    }
}
