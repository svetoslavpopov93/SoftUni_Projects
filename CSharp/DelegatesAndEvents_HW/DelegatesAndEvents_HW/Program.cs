using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace DelegatesAndEvents_HW
{
    class Program
    {
        protected static double CalculateSimpleInterest(double sum, double interest, int years)
        {
            double A = sum * (double)(1 + (interest * years / 100));

            return A;
        }

        protected static double CalculateCompoundInterest(double sum, double interest, int years)
        {
            double A = sum * (double)Math.Pow(1 + (interest / 12 / 100), years * 12);

            return A;
        }

        static void Main()
        {
            //double money = 500;
            //double interest = 5.6;
            //int years = 10;

            InterestCalculator calc = new InterestCalculator(500, 5.6, 10, CalculateCompoundInterest);
            //InterestCalculator calc = new InterestCalculator(2500, 7.2, 15, CalculateSimpleInterest);

            Console.WriteLine("{0:0.0000}", calc.PaybackValue);
        }
    }
}
