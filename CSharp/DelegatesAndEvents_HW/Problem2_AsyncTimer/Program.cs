using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Problem2_AsyncTimer
{
    class Program
    {
        public void prt()
        {
            Console.WriteLine("boooom!");
        }

        static void Main(string[] args)
        {
            Action magic = () =>
            {
                Console.WriteLine("boom!");
            };

            AsyncTimer asinc = new AsyncTimer(888, 5, magic);

            asinc.Repeat();

            Console.WriteLine("Enter something to show the async work.");
            Console.WriteLine(Console.ReadLine());

        }
    }
}
