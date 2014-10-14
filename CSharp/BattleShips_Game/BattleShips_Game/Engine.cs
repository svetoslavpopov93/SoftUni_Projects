using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShips_Game
{
    class Engine
    {
        private List<List<char>> gameBoard;
        private Battleship battleShip;
        private Destroyer firstDestroyer;
        private Destroyer secondDestroyer;
        private int inputX;
        private int inputY;
        private int turnsCount;

        public Engine()
        {
            gameBoard = GenerateGameBoard();
            turnsCount = 0;
            AddShips();
        }

        private List<List<char>> GenerateGameBoard()
        {
            List<List<char>> generatedGameBoard = new List<List<char>>();

            for (int i = 0; i < 10; i++)
            {
                generatedGameBoard.Add(new List<char>());

                for (int j = 0; j < 10; j++)
                {
                    generatedGameBoard[i].Add('.');
                }
            }

            return generatedGameBoard;
        }

        public void PrintGameBoard()
        {
            Console.WriteLine("  1 2 3 4 5 6 7 8 9 10");
            int index = 0;

            foreach (var line in gameBoard)
            {
                Console.Write((char)(65 + index));
                index++;

                foreach (var element in line)
                {
                    if (element == '#' | element == '@')
                    {
                        Console.Write(" .");
                    }
                    else
                    {
                        Console.Write(" " + element);
                    }
                }

                Console.WriteLine();
            }
        }

        private void AddShips()
        {
            AddBattleShip();
            AddFirstDestroyer();
            AddSecondDestroyer();
        }

        /// <summary>
        /// Adds a Battle ship with 5 parts, at random position and random direction (vertical or horisontal)
        /// </summary>
        public void AddBattleShip()
        {
            battleShip = new Battleship();
            List<ShipPart> parts = battleShip.Parts;
            bool emptyField = true;

            // Performs a check depending on the direction, to prevent overlapping
            for (int i = 0; i < battleShip.Parts.Count; i++)
            {
                if (gameBoard[parts[i].X][parts[i].Y] != '.')
                {
                    emptyField = false;
                    break;
                }
            }

            // If there is overlapping found the same method is called recursively
            if (emptyField == false)
            {
                AddBattleShip();
            }

            else
            {
                for (int i = 0; i < battleShip.Parts.Count; i++)
                {
                    gameBoard[parts[i].X][parts[i].Y] = '@';
                }
            }
        }

        /// <summary>
        /// Adds a Destroyer ship with 4 parts, at random position and random direction (vertical or horisontal)
        /// </summary>
        private void AddFirstDestroyer()
        {
            firstDestroyer = new Destroyer();
            List<ShipPart> parts = firstDestroyer.Parts;
            bool emptyField = true;

            // Performs a check depending on the direction, to prevent overlapping
            for (int i = 0; i < firstDestroyer.Parts.Count; i++)
            {
                if (gameBoard[parts[i].X][parts[i].Y] != '.')
                {
                    emptyField = false;
                    break;
                }
            }

            // If there is overlapping found the same method is called recursively
            if (emptyField == false)
            {
                AddFirstDestroyer();
            }

            else
            {
                for (int i = 0; i < firstDestroyer.Parts.Count; i++)
                {
                    gameBoard[parts[i].X][parts[i].Y] = '#';
                }
            }
        }

        /// <summary>
        /// Adds a Destroyer ship with 4 parts, at random position and random direction (vertical or horisontal)
        /// </summary>
        private void AddSecondDestroyer()
        {
            secondDestroyer = new Destroyer();
            List<ShipPart> parts = secondDestroyer.Parts;
            bool emptyField = true;

            // Performs a check depending on the direction, to prevent overlapping
            for (int i = 0; i < secondDestroyer.Parts.Count; i++)
            {
                if (gameBoard[parts[i].X][parts[i].Y] != '.')
                {
                    emptyField = false;
                    break;
                }
            }

            // If there is overlapping found the same method is called recursively
            if (emptyField == false)
            {
                AddSecondDestroyer();
            }

            else
            {
                for (int i = 0; i < secondDestroyer.Parts.Count; i++)
                {
                    gameBoard[parts[i].X][parts[i].Y] = '#';
                }
            }
        }

        /// <summary>
        /// Reads the user input and converts the input in the needed format
        /// </summary>
        private void ReadUserInput()
        {
            Console.WriteLine("Enter coordinates in format e.g. A2:");

            string input = Console.ReadLine();
            string vertical, horisontal;

            if (input.Length == 3)
            {
                vertical = input[0] + "";
                horisontal = input[1] + "" + input[2];
            }
            else
            {
                vertical = "" + input[0];
                horisontal = "" + input[1];
            }

            int numX = 0;
            int numY = 0;

            numY = (int)((char)vertical.ToLower()[0]) - 97;
            numX = int.Parse(horisontal) - 1;
            inputY = numY;
            inputX = numX;
        }

        /// <summary>
        /// Checks if the user hits or misses ship and applies changes to the parts of the ship on hit.
        /// </summary>
        private void CheckInput()
        {
            if (gameBoard[inputY][inputX] == '.')
            {
                turnsCount++;
                gameBoard[inputY][inputX] = '-';
                Console.WriteLine("---miss---");
                Console.WriteLine("{0} moves ware made.", turnsCount);
            }

            // On the game board with '#' are marked the Destroyers parts and with '@' are market the Battle ship parts
            // If the user hits a ship the status of the hitted part is changed.
            else if (gameBoard[inputY][inputX] == '#' | gameBoard[inputY][inputX] == '@')
            {
                turnsCount++;
                gameBoard[inputY][inputX] = 'X';
                Console.Beep();
                Console.WriteLine("---HIT!--- ");
                UpdateFirstDestroyerParts(inputY, inputX);
                UpdateSecondDestroyerParts(inputY, inputX);
                UpdateBattleShip(inputY, inputX);
                Console.WriteLine("{0} moves ware made.", turnsCount);
            }

            // Performs a check if the user hits on a same place twice
            else if (gameBoard[inputY][inputX] == 'X' | gameBoard[inputY][inputX] == '-')
            {
                turnsCount++;
                gameBoard[inputY][inputX] = 'X';
                Console.WriteLine("Double hit");
                Console.WriteLine("{0} moves ware made.", turnsCount);
            }
        }

        /// <summary>
        /// Searches all parts of the first Destroyer and if the coordinates of the user input matches with a part from the ship
        /// the part is destroyed using the implemented method in its class
        /// </summary>
        /// <param name="xIndex">Matches the X coordinate parameter</param>
        /// <param name="yIndex">Matches the Y coordinate parameter</param>
        private void UpdateFirstDestroyerParts(int xIndex, int yIndex)
        {
            foreach (var part in this.firstDestroyer.Parts)
            {
                if (part.X == xIndex && part.Y == yIndex)
                {
                    part.DestroyPart();
                    break;
                }
            }
        }

        /// <summary>
        /// Searches all parts of the second Destroyer and if the coordinates of the user input matches with a part from the ship
        /// the part is destroyed using the implemented method in its class
        /// </summary>
        /// <param name="xIndex">Matches the X coordinate parameter</param>
        /// <param name="yIndex">Matches the Y coordinate parameter</param>
        private void UpdateSecondDestroyerParts(int xIndex, int yIndex)
        {
            foreach (var part in this.secondDestroyer.Parts)
            {
                if (part.X == xIndex && part.Y == yIndex)
                {
                    part.DestroyPart();
                    break;
                }
            }
        }

        /// <summary>
        /// Searches all parts of the Battleship and if the coordinates of the user input matches with a part from the ship
        /// the part is destroyed using the implemented method in its class
        /// </summary>
        /// <param name="xIndex">Matches the X coordinate parameter</param>
        /// <param name="yIndex">Matches the Y coordinate parameter</param>
        private void UpdateBattleShip(int xIndex, int yIndex)
        {
            foreach (var part in battleShip.Parts)
            {
                if (part.X == xIndex && part.Y == yIndex)
                {
                    part.DestroyPart();
                    break;
                }
            }
        }

        /// <summary>
        /// Checks if all parts of the first Destroyer ship are destroyed
        /// </summary>
        /// <returns>True of False</returns>
        public bool CheckFirstDestroyer()
        {
            bool isAlive = true;

            foreach (var element in firstDestroyer.Parts)
            {
                if (element.IsAlive == false)
                {
                    isAlive = false;
                }

                if (isAlive == false && element.IsAlive == true)
                {
                    isAlive = true;
                    break;
                }
            }

            return isAlive;
        }

        /// <summary>
        /// Checks if all parts of the second Destroyer ship are destroyed
        /// </summary>
        /// <returns>True of False</returns>
        public bool CheckSecondDestroyer()
        {
            bool isAlive = true;

            foreach (var element in secondDestroyer.Parts)
            {
                if (element.IsAlive == false)
                {
                    isAlive = false;
                }

                if (isAlive == false && element.IsAlive == true)
                {
                    isAlive = true;
                    break;
                }
            }

            return isAlive;
        }

        /// <summary>
        /// Checks if all parts of the Battleship are destroyed
        /// </summary>
        /// <returns>True of False</returns>
        public bool CheckBattleship()
        {
            bool isAlive = true;

            foreach (var element in battleShip.Parts)
            {
                if (element.IsAlive == false)
                {
                    isAlive = false;
                }

                if (isAlive == false && element.IsAlive == true)
                {
                    isAlive = true;
                    break;
                }
            }

            return isAlive;
        }

        /// <summary>
        /// Checks all ships for their current status. If all of their parts are destroyed, the ship's "sink" method is called
        /// </summary>
        private void UpdateShipStatus()
        {
            if (CheckFirstDestroyer() == false)
            {
                firstDestroyer.SinkShip();
            }
            if (CheckSecondDestroyer() == false)
            {
                secondDestroyer.SinkShip();
            }
            if (CheckBattleship() == false)
            {
                battleShip.SinkShip();
            }
        }

        /// <summary>
        /// Checks if all ships are still alive.
        /// </summary>
        /// <returns>True of False</returns>
        private bool UpdateGameStatus()
        {
            if (!firstDestroyer.IsAlive && !secondDestroyer.IsAlive && !battleShip.IsAlive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintEndGameMessage(int turns)
        {
            Console.Clear();
            Console.WriteLine("Well done! You completed the game in {0} turns.", turns);
        }

        public void Run()
        {
            PrintGameBoard();
            bool gameFinished = false;

            while (true)
            {
                ReadUserInput();
                Console.Clear();
                CheckInput();
                UpdateShipStatus();
                PrintGameBoard();
                gameFinished = UpdateGameStatus();

                if (gameFinished)
                {
                    break;
                }

                Thread.Sleep(150);
            }

            PrintEndGameMessage(turnsCount);
        }
    }
}
