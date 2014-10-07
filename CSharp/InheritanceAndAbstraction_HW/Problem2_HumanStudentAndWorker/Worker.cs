using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_HumanStudentAndWorker
{
    class Worker : Human
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double WeekSalary { get; private set; }
        public int WorkHoursPerDay { get; private set; }
        public double MoneyPerHour { get; set; }

        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
            this.MoneyPerHour = CalculateMoneyPerHour();
        }

        public double CalculateMoneyPerHour()
        {
            double totalWorkHoursPerWeek = WorkHoursPerDay * 5;
            double weeksMoneyPerHour = totalWorkHoursPerWeek / WeekSalary;

            return weeksMoneyPerHour;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, Week salary = {2}, Work hours per day = {3}, Money per hour = {4}", FirstName, LastName, WeekSalary, WorkHoursPerDay, MoneyPerHour);
        }
    }
}
