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
            Console.Clear();
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
                    gameBoard[parts[i].X][parts[i].Y] = '#';
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
            string x, y;
            if (input.Length == 2)
            {
                x = input[0] + "";
                y = input[1] + "";
            }
            else
            {
                x = input[0] + "";
                y = input[1] + "" + input[2];
            }

            switch (x)
            {
                case "A":
                    inputY = 0;
                    break;
                case "B":
                    inputY = 1;
                    break;
                case "C":
                    inputY = 2;
                    break;
                case "D":
                    inputY = 3;
                    break;
                case "E":
                    inputY = 4;
                    break;
                case "F":
                    inputY = 5;
                    break;
                case "G":
                    inputY = 6;
                    break;
                case "H":
                    inputY = 7;
                    break;
                case "I":
                    inputY = 8;
                    break;
                case "J":
                    inputY = 9;
                    break;
                default:
                    break;
            }

            inputX = int.Parse(y) - 1;
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
            else if (gameBoard[inputY][inputX] == '#')
            {
                turnsCount++;
                gameBoard[inputY][inputX] = 'X';
                Console.WriteLine("---HIT!--- ");
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

        public void Run()
        {
            PrintGameBoard();

            while (true)
            {
                ReadUserInput();
                CheckInput();
                PrintGameBoard();
                Thread.Sleep(150);
            }
        }
    }
}
