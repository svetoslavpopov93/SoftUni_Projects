using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_HumanStudentAndWorker
{
    class Student : Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FacultyNumber { get; set; }

        public Student(string firstName, string lastName, int facultyNumber) : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, [{2}]", this.FirstName, this.LastName, this.FacultyNumber);
        }
    }
}
