using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_School
{
    class School : SchoolMember
    {
        protected string Name { get; set; }
        protected List<Class> Classes { get; set; }

        public School(string name, List<Class> classes) : base(name)
        {
            this.Name = name;
            this.Classes = classes;
        }

        public override string ToString()
        {
            string classesStr = "";
            foreach (var cl in Classes)
            {
                classesStr += cl + " ";
            }

            return this.Name + " with classes: " + classesStr;
        }
    }
}
