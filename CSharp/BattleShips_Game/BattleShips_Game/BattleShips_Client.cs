using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips_Game
{
    class BattleShips_Client
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Battle Ships: The game");
            Console.WriteLine("\r\n-----------Game rules:-----------");
            Console.WriteLine("You have two Destroyer ships and");
            Console.WriteLine("one Battleship heading your way.");
            Console.WriteLine("Destroy them as soon as possible.");
            Console.WriteLine("\r\n\r\nPress space bar to start the game!");

            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    break;
                }
            }

            Console.Clear();

            Engine engine = new Engine();

            engine.Run();
        }
    }
}
