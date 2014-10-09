using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Shapes
{
    class Circle : IShape
    {
        private double radius;

        public double Radius
        {
            get
            {
                if (this.radius <= 0)
                {
                    throw new ArgumentException("Input value must be greater than ZERO!");
                }

                return this.radius;
            }
            set
            {
                this.radius = value;
            }
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double CalculateArea()
        {
            double calcArea = Math.PI * (radius * radius);
            return calcArea;
        }

        public double CalculatePerimeter()
        {
            double calcPerimeter = 2 * Math.PI * radius;
            return calcPerimeter;
        }
    }
}
