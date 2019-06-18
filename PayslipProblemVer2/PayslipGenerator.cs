using System;

namespace PayslipProblemVer2
{
    public class PayslipGenerator
    {
        private readonly IncomeTaxCalculator _incomeTaxCalculator;

        public PayslipGenerator()
        {
            _incomeTaxCalculator = new IncomeTaxCalculator();
        }
        
        public string GetPayslip(Employee employee, Period period)
        {
            return $"{GetName(employee)}\n" +
                   $"{GetPeriod(period)}\n" +
                   $"{GetGrossIncome(employee.AnnualSalary)}\n" +
                   $"{GetIncomeTax(employee)}\n";
        }

        private string GetIncomeTax(Employee employee)
        {
            var income = _incomeTaxCalculator.Calculate(employee.AnnualSalary);
            return $"Income Tax: {income}";
        }

        private string GetGrossIncome(uint annualSalary)
        {
            return $"Gross Income: {CalculateGross(annualSalary)}";
        }


        private uint CalculateGross(uint annualSalary)
        {
            return annualSalary / 12;
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