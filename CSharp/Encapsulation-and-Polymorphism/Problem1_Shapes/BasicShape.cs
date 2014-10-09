using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Shapes
{
    abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            { }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            { }
        }

        public BasicShape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}
