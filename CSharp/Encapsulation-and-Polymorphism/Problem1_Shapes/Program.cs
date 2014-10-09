using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Triangle:");
            Triangle tr = new Triangle(21, 5);

            Console.WriteLine(tr.C);
            Console.WriteLine(tr.Area);
            Console.WriteLine(tr.Perimeter);

            Console.WriteLine("Rectangle:");
            Rectangle rec = new Rectangle(8, 7);

            Console.WriteLine(rec.Area);
            Console.WriteLine(rec.Perimeter);
        }
    }
}
