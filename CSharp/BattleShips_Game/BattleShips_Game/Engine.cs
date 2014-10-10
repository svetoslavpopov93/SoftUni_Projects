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
        private Battleship battleShip1;
        //Destroyer

        public Engine()
        {
            gameBoard = GenerateGameBoard();
            AddBattleShip(); AddBattleShip1();
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
            AddBattleShip1();
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
        public void AddBattleShip1()
        {
            battleShip1 = new Battleship();
            List<ShipPart> parts = battleShip1.Parts;
            bool emptyField = true;

            for (int i = 0; i < battleShip1.Parts.Count; i++)
            {
                if (gameBoard[parts[i].X][parts[i].Y] != '.')
                {
                    emptyField = false;
                    break;
                }
            }

            if (emptyField == false)
            {
                AddBattleShip1();
            }

            else
            {
                for (int i = 0; i < battleShip1.Parts.Count; i++)
                {
                    gameBoard[parts[i].X][parts[i].Y] = '#';
                }
            }
        }

        private void AddDestroyer()
        {
        }

        private void Run()
        {
            //// TO DO
            PrintGameBoard();
        }
    }
}
