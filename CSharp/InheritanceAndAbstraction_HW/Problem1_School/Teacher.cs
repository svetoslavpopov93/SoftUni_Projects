using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1_School
{
    class Teacher : Person
    {
        protected string Name { get; set; }
        protected List<Discipline> Disciplines { get; set; }
        protected string Details { get; set; }

        public Teacher(string name, List<Discipline> disciplines, string details = null) : base(name)
        {
            this.Name = name;
            this.Disciplines = disciplines;
            this.Details = details;
        }

        // TODO
        // Override ToString()
    }
}
