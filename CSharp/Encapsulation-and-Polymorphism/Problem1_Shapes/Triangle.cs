using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Shapes
{
    class Triangle : BasicShape
    {
        private double a;
        private double b;
        private double c;
        private double perimeter;
        private double area;

        public double A
        {
            get
            {
                if (this.a <= 0)
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
                if (this.b <= 0)
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

        public double C
        {
            get
            {
                if (this.c <= 0)
                {
                    throw new ArgumentException("Input value must be greater than zero!");
                }
                return this.c;
            }
            set
            {
                this.c = value;
            }
        }

        public double Perimeter
        {
            get
            {
                return CalculatePerimeter();
            }
            private set
            {
                this.perimeter = value;
            }
        }

        public double Area
        {
            get
            {
                return CalculateArea();
            }
            private set
            {
                this.area = value;
            }
        }

        public Triangle(double a, double b):base(a, b)
        {
            this.a = a;
            this.b = b;
            this.c = Math.Sqrt((A * A) + (B * B));
        }

        public override double CalculateArea()
        {
            double calcArea = (A * B) / 2;
            return calcArea;
        }

        public override double CalculatePerimeter()
        {
            double calcPerimeter = A + B + C;
            return calcPerimeter;
        }
    }
}
