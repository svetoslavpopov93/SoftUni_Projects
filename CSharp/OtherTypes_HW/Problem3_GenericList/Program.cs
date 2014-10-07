using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListOfT
{
    class Program
    {
        static void Main()
        {
            GenericList<string> list = new GenericList<string>(3);

            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Add("bam");
            list.Add("three");
            list.Remove(3);
            list.Add("three");
            list.Add("three");

            list.Add("three");

            //list.Instert(0, "twoOnOne");

            //list.Clear();
            //list.FindIndex("two");
            Console.WriteLine(list);
        }
    }
}
