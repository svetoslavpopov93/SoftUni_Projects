using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    struct Fraction
    {
        private double numerator;
        private double denominator;

        public Fraction(double numerator, double denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public double Numerator
        {
            get
            {
                return this.numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public double Denominator
        {
            get
            {
                if (this.denominator == 0)
                {
                    throw new DivideByZeroException("Denominator value can not be ZERO.");
                }
                else
                {
                    return this.denominator;
                }
            }
            set
            {
                denominator = value;
            }
        }

        //public static Fraction operator +(Fraction a, Fraction b)
        //{
        //    Fraction temp
        //}

    }

    class Program
    {
        static void Main()
        {
        }
    }
}
