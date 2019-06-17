using System;

namespace PayslipProblemVer2
{
    public class PayslipGenerator
    {
        public string GetPayslip(Employee employee, Period period)
        {
            return $"{GetName(employee)}\n" +
                   GetPeriod(period);
        }

        private string GetPeriod(Period period)
        {
            return $"Pay Period: {GetFormattedDate(period.StartDate)} - {GetFormattedDate(period.EndDate)}";
        }

        private string GetFormattedDate(DateTime date)
        {
            return date.ToString("dd MMMM");
        }

        private string GetName(Employee employee)
        {
            return $"Name: {employee.Name} {employee.Surname}";
        }
    }
}