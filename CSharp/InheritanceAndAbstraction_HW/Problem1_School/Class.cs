using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1_School
{
    class Class : SchoolMember
    {
        protected string Name { get; set; }
        protected List<Teacher> Teachers { get; set; }
        protected string Details { get; set; }
        
        
        public Class(string name, List<Teacher> teachers, string details = null) : base(name)
        {
            this.Name = name;
            this.Teachers = teachers;
            this.Details = details;
        }

        // TODO
        // override ToString()
    }
}
