using System;

namespace ExceptionHandling_HW
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello! Please enter the number:");
            int input = 0;
            double squareRoot = 0;

            try
            {
                input = int.Parse(Console.ReadLine());
                squareRoot = Math.Sqrt(input);
                
                Console.WriteLine(squareRoot);
            }
            catch (ArgumentOutOfRangeException argOutOfRange)
            {
                Console.WriteLine("Input number is too long.");
            }
            catch (OverflowException ovrFlow)
            {
                Console.WriteLine("Input number is too long.");
            }
            catch (FormatException format)
            {
                Console.WriteLine("Invalid input format.");
            }
            catch (ArgumentNullException argNull)
            {
                Console.WriteLine("Input can not be null.");
            }
            catch (ArgumentException arg)
            {
                Console.WriteLine("Invalid input arguments.");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
