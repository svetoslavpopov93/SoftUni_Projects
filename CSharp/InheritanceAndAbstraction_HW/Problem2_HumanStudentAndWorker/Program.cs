using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_HumanStudentAndWorker
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("////////////STUDENTS\\\\\\\\\\\\");

            Student vanio = new Student("Vanio", "Vaniov", 123142424);
            Student kiko = new Student("Kiko", "Kikov", 123142425);
            Student mitko = new Student("Mitko", "Mitkov", 123142424);
            Student danio = new Student("Danio", "Dimitrov", 152452444);
            Student genio = new Student("Georgi", "Pashov", 123142424);
            Student kika = new Student("Kika", "Ivanova", 123142425);
            Student iva = new Student("Iva", "Stoqnova", 123142424);
            Student doncho = new Student("Doncho", "Stavrov", 123737743);
            Student anton = new Student("Anton", "Minev", 123534424);
            Student kozmin = new Student("Kozmin", "Moci", 234442424);

            List<Student> students = new List<Student>() 
            {
                vanio, kiko, kozmin, mitko, danio, genio, kika, iva, doncho, anton
            };

            Console.WriteLine("Before sorting.");
            // Before sorting
            foreach (var st in students)
            {
                Console.WriteLine(st);
            }

            // Sorting
            IEnumerable<Student> sortedStudents = students.OrderBy(st => st.FacultyNumber);
            
            Console.WriteLine("\r\n\r\nAfter sorting.\r\n");
            // After sorting
            foreach (var st in sortedStudents)
            {
                Console.WriteLine(st);
            }

            Console.WriteLine("\r\n\r\n////////////WORKERS\\\\\\\\\\\\");

            Worker kristian = new Worker("Kristian", "Borovinov", 200, 8);
            Worker stoil = new Worker("Stoil", "Yotsov", 240, 6);
            Worker petar = new Worker("Petar", "Petrov", 290, 8);
            Worker elena = new Worker("Elena", "Dimitrova", 260, 9);
            Worker ivan = new Worker("Ivan", "Dimitrov", 210, 8);
            Worker spaska = new Worker("Spaska", "Peianina", 100, 3);
            Worker cvetelina = new Worker("Cvetelina", "Stamenova", 200, 8);
            Worker georgi = new Worker("Georgi", "Dashov", 500, 7);
            Worker rumen = new Worker("Rumen", "Gionov", 300, 8);
            Worker vasil = new Worker("Vasil", "Sirakov", 200, 9);

            List<Worker> workers = new List<Worker>()
            {
                kristian,
                stoil,
                petar,
                elena,
                ivan,
                spaska,
                cvetelina,
                georgi,
                rumen,
                vasil
            };

            Console.WriteLine("\r\n\r\nWorkers before Sorting");
            // Before sorting
            foreach (var wk in workers)
            {
                Console.WriteLine(wk);
            }
            
            // Sorting
            IEnumerable<Worker> sortedWorkers = workers.OrderBy(wk => wk.MoneyPerHour);

            Console.WriteLine("\r\n\r\nAfter sorting.\r\n");
            // After sorting
            foreach (var wk in sortedWorkers)
            {
                Console.WriteLine(wk);
            }

            // Merge both
            List<Human> humans = new List<Human>();

            foreach (var st in students)
            {
                humans.Add(st);
            }

            foreach (var wk in workers)
            {
                humans.Add(wk);
            }

            IEnumerable<Human> sortedHumans = humans.OrderBy(person => person.FirstName).ThenBy(person => person.LastName);
        }
    }
}
