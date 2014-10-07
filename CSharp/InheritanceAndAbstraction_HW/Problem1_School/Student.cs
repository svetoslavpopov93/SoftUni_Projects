using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1_School
{
    class Student : Person
    {
        protected string Name { get; set; }
        protected int UniqueClassNumber { get; set; }
        protected string Details { get; set; }

        public Student(string name, int uniqueClassNumber, string details = null) : base(name)
        {
            this.Name = name;
            this.UniqueClassNumber = uniqueClassNumber;
            this.Details = details;
        }
    }
}
