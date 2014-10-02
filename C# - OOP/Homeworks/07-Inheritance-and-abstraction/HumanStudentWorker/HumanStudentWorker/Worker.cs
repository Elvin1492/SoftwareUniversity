
namespace HumanStudentWorker
{
    using System;

    // define a class Worker which derives from Human
    public class Worker : Human
    {
        private decimal weekSalary;
        private byte workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, byte workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary 
        {
            get { return this.weekSalary; }
            private set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException("Week Salary", 
                        "Week Salary should be a decimal number in  between 0 and 1000");
                }

                this.weekSalary = value;
            }
        }

        public byte WorkHoursPerDay 
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if (value > 12)
                {
                    throw new ArgumentOutOfRangeException("Work hours per day",
                        "Work hours per day can not be more than 12.");
                }

                this.workHoursPerDay = value;
            }
        }

        // define a method for calculation the payment per hour for a worker
        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        // override the ToString method
        public override string ToString()
        {
            return base.ToString() +
                String.Format(", Week Salary: {0}, WorkHours per/day: {1}, Money per/hour: {2:0.00}",
                this.WeekSalary, this.workHoursPerDay, this.MoneyPerHour());
        }
    }
}
