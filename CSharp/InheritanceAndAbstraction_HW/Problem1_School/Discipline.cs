using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1_School
{
    class Discipline : SchoolMember
    {
        protected string Name { get; set; }
        protected List<Student> Students { get; set; }
        protected string Details { get; set; }

        public Discipline(string name, List<Student> students, string details = null) : base(name)
        {
            this.Name = name;
            this.Students = students;
            this.Details = details;
        }
    }
}
