using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_School
{
    class Person : SchoolMember
    {
        protected string Name { get; set; }

        public Person(string name) : base(name)
        {
            this.Name = name;
        }
    }
}
