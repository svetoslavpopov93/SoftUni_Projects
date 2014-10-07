using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_School
{
    class Program
    {
        static void Main(string[] args)
        {
            Student svetoslav = new Student("Svetoslav Popov", 21);
            Student aleko = new Student("Aleko Mladenov", 2);
            Student zlaty = new Student("Zlaty Angelov", 7);
            Discipline sport = new Discipline("Sportna paralelka", new List<Student>(){svetoslav, aleko, zlaty});
            Teacher radeva = new Teacher("Radeva", new List<Discipline>(){sport});
            Class eightB = new Class("8b klas)", new List<Teacher> (){radeva});
            School klimentOhridski = new School("OU Kliment Ohridski", new List<Class>(){eightB});
        }
    }
}
