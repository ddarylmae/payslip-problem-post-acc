using System;

namespace PayslipProblemVer2
{
    public class PayslipGenerator
    {
        public Payslip GeneratePayslip(Employee employee, Period period)
        {
            return new Payslip
            {
                Name = GetName(employee),
                Period = GetPeriod(period)
            };
        }

        private string GetPeriod(Period period)
        {
            return $"{GetFormattedDate(period.StartDate)} - {GetFormattedDate(period.EndDate)}";
        }

        private string GetFormattedDate(DateTime date)
        {
            return date.ToString("dd MMMM");
        }

        private string GetName(Employee employee)
        {
            return $"{employee.Name} {employee.Surname}";
        }
    }
}