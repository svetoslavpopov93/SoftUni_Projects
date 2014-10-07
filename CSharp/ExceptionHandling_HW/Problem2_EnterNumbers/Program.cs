using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_EnterNumbers
{
    class Program
    {
        static void Main()
        {
            ReadNumbers(23, 54);
        }

        public static void ReadNumbers(int start, int end)
        {
            int[] numbers = new int[10];
            int input = 0;

            Console.WriteLine("Please enter numbers in range [{0}...{1}]", start, end);

            for (int i = 0; i < 10; i++)
            {
                while (true)
                {
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                        if (input < start | input > end)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        numbers[i] = input;
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid number, please enter new one.");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Please enter number in range [{0}...{1}]", start, end);
                    }
                }
            }
        }
    }
}
