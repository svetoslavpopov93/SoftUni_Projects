using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Shapes
{
    class Rectangle : BasicShape
    {
        private double a;
        private double b;

        public double A
        {
            get
            {
                if (a <= 0)
                {
                    throw new ArgumentException("Input value must be greater than zero!");
                }

                return this.a;
            }
            set
            {
                this.a = value;
            }
        }

        public double B
        {
            get
            {
                if (b <= 0)
                {
                    throw new ArgumentException("Input value must be greater than zero!");
                }

                return this.b;
            }
            set
            {
                this.b = value;
            }
        }

        public Rectangle(double a, double b) : base(a, b)
        {
            this.a = a;
            this.b = b;
        }

        public override double CalculateArea()
        {
            double calcArea = A * B;
            return calcArea;
        }

        public override double CalculatePerimeter()
        {
            double calcPerimeter = (2 * a) + (2 * b);
            return calcPerimeter;
        }
    }
}
