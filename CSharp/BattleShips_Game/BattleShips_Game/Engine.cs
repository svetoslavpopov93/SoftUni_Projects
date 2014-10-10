using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips_Game
{
    class Engine
    {
        private List<List<char>> gameBoard;
        private Battleship battleShip;
        private Destroyer firstDestroyer;
        private Destroyer secondDestroyer;
        //Destroyer

        public Engine()
        {
            gameBoard = GenerateGameBoard();
            //AddBattleShip();
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

        private void Run()
        {
            //// TO DO
            PrintGameBoard();
        }
    }
}
