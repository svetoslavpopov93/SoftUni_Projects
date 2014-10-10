using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            Battleship testShip = new Battleship();

            engine.PrintGameBoard();
        }
    }
}
