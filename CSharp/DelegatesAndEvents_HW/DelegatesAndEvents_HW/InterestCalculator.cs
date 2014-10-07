using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents_HW
{
    class InterestCalculator
    {
        double sumOfMoney;
        double interest;
        int years;
        double paybackVal;
        public delegate double CalculateInterest(double sum, double interest, int years);

        public InterestCalculator(double sum, double interest, int years, CalculateInterest del)
        {
            this.sumOfMoney = sum;
            this.interest = interest;
            this.years = years;
            this.paybackVal = del(sum, interest, years);
        }

        public double SumOfMoney
        {
            get
            {
                return this.sumOfMoney;
            }
            set
            {
                sumOfMoney = value;
            }
        }
        public double Interest
        {
            get
            {
                return this.interest;
            }
            set
            {
                interest = value;
            }
        }
        public int Years
        {
            get
            {
                return this.years;
            }
            set
            {
                years = value;
            }
        }

        public double PaybackValue
        {
            get
            {
                return paybackVal;
            }
            set
            {
                paybackVal = value;
            }
        }
    }
}
