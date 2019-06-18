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
                   $"{GetNetIncome(employee.AnnualSalary)}\n" +
                   $"{GetIncomeTax(employee.AnnualSalary)}\n";
        }

        private string GetNetIncome(uint annualSalary)
        {
            var grossIncome = CalculateGross(annualSalary);
            var incomeTax = CalculateTax(annualSalary);
            var netIncome = grossIncome - incomeTax;
            return $"Net Income: {netIncome}";
        }

        private string GetIncomeTax(uint annualSalary)
        {
            var income = CalculateTax(annualSalary);
            return $"Income Tax: {income}";
        }

        private uint CalculateTax(uint annualSalary)
        {
            return _incomeTaxCalculator.Calculate(annualSalary);
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