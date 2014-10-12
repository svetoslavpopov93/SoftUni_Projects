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
            turnsCount = -1;
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
            foreach (var line in gameBoard)
            {
                foreach (var element in line)
                {
                    Console.Write(element);
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
        /// //////////////////////possible misstake here
        /// </summary>
        public void AddBattleShip()
        {
            battleShip = new Battleship();
            List<ShipPart> parts = battleShip.Parts;
            bool emptyField = true;

            for (int i = 0; i < battleShip.Parts.Count; i++)
            {
                if (gameBoard[parts[i].X][parts[i].Y] != '.')
                {
                    emptyField = false;
                    break;
                }
            }

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

        private void AddFirstDestroyer()
        {
            firstDestroyer = new Destroyer();
            List<ShipPart> parts = firstDestroyer.Parts;
            bool emptyField = true;

            for (int i = 0; i < firstDestroyer.Parts.Count; i++)
            {
                if (gameBoard[parts[i].X][parts[i].Y] != '.')
                {
                    emptyField = false;
                    break;
                }
            }

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

        private void AddSecondDestroyer()
        {
            secondDestroyer = new Destroyer();
            List<ShipPart> parts = secondDestroyer.Parts;
            bool emptyField = true;

            for (int i = 0; i < secondDestroyer.Parts.Count; i++)
            {
                if (gameBoard[parts[i].X][parts[i].Y] != '.')
                {
                    emptyField = false;
                    break;
                }
            }

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

        private void ReadUserInput()
        {
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

            switch (vertical)
            {
                case "A":
                    numY = 0;
                    break;
                case "B":
                    numY = 1;
                    break;
                case "C":
                    numY = 2;
                    break;
                case "D":
                    numY = 3;
                    break;
                case "E":
                    numY = 4;
                    break;
                case "F":
                    numY = 5;
                    break;
                case "G":
                    numY = 6;
                    break;
                case "H":
                    numY = 7;
                    break;
                case "I":
                    numY = 8;
                    break;
                case "J":
                    numY = 9;
                    break;
                default:
                    break;
            }

            numX = int.Parse(horisontal) - 1;
            inputY = numY;
            inputX = numX;
        }

        private void CheckInput()
        {
            if (gameBoard[inputY][inputX] == '.')
            {
                turnsCount++;
                gameBoard[inputY][inputX] = '-';
                Console.WriteLine("---miss---");
                Console.WriteLine("{0} moves ware made.", turnsCount);
            }
            else if (gameBoard[inputY][inputX] == '#' | gameBoard[inputY][inputX] == '@')
            {
                turnsCount++;
                gameBoard[inputY][inputX] = 'X';
                Console.Beep();
                Console.WriteLine("---HIT!--- ");
                UpdateFirstDestroyerParts(inputY, inputX);
                UpdateSecondDestroyerParts(inputY, inputX);
                UpdateBattleShip(inputY, inputX);
                // TODO: check all ships if user hitted them!
                Console.WriteLine("{0} moves ware made.", turnsCount);
            }
            else if (gameBoard[inputY][inputX] == 'X')
            {
                turnsCount++;
                gameBoard[inputY][inputX] = 'X';
                Console.WriteLine("Double hit");
                Console.WriteLine("{0} moves ware made.", turnsCount);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        private void UpdateFirstDestroyerParts(int firstIndex, int secondIndex)
        {
            foreach (var part in this.firstDestroyer.Parts)
            {
                if (part.X == firstIndex && part.Y == secondIndex)
                {
                    part.DestroyPart();
                    break;
                }
            }
        }

        private void UpdateSecondDestroyerParts(int x, int y)
        {
            foreach (var part in this.secondDestroyer.Parts)
            {
                if (part.X == x && part.Y == y)
                {
                    part.DestroyPart();
                    break;
                }
            }
        }

        private void UpdateBattleShip(int x, int y)
        {
            foreach (var part in battleShip.Parts)
            {
                if (part.X == x && part.Y == y)
                {
                    part.DestroyPart();
                    break;
                }
            }
        }

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

        public void PrintEndGameMessage(int turns)
        {
            Console.Clear();
            Console.WriteLine("You have finished the game with {0} turns.", turns);
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

                PrintGameBoard();
                Thread.Sleep(150);
            }

            PrintEndGameMessage(turnsCount);
        }
    }
}
