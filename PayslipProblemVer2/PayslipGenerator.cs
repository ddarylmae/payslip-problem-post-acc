using System;

namespace PayslipProblemVer2
{
    public class PayslipGenerator
    {
        private readonly IncomeTaxCalculator _incomeTaxCalculator;
        private Employee _employee;

        public PayslipGenerator(ITaxRates taxRates)
        {
            _incomeTaxCalculator = new IncomeTaxCalculator(taxRates);
        }
        
        public string GetPayslip(Employee employee, Period period)
        {
            _employee = employee;
            return $"{GetName()}\n" +
                   $"{GetPeriod(period)}\n" +
                   $"{GetGrossIncome()}\n" +
                   $"{GetNetIncome()}\n" +
                   $"{GetIncomeTax()}\n" +
                   $"{GetSuper()}\n";
        }

        private string GetSuper()
        {
            var super = CalculateSuper();

            return $"Super: {super}";
        }

        private double CalculateSuper()
        {
            var gross = CalculateGross();
            var super = gross * (_employee.SuperRate / 100.0);
            
            return Math.Round(super);
        }

        private string GetNetIncome()
        {
            return $"Net Income: {CalculateNetIncome()}";
        }

        private uint CalculateNetIncome()
        {
            var grossIncome = CalculateGross();
            var incomeTax = CalculateTax();
            var netIncome = grossIncome - incomeTax;
            return netIncome;
        }

        private string GetIncomeTax()
        {
            var income = CalculateTax();
            return $"Income Tax: {income}";
        }

        private uint CalculateTax()
        {
            return _incomeTaxCalculator.Calculate(_employee.AnnualSalary);
        }

        private string GetGrossIncome()
        {
            return $"Gross Income: {CalculateGross()}";
        }


        private uint CalculateGross()
        {
            return _employee.AnnualSalary / 12;
        }

        private string GetPeriod(Period period)
        {
            return $"Pay Period: {GetFormattedDate(period.StartDate)} - {GetFormattedDate(period.EndDate)}";
        }

        private string GetFormattedDate(DateTime date)
        {
            return date.ToString("dd MMMM");
        }

        private string GetName()
        {
            return $"Name: {_employee.Name} {_employee.Surname}";
        }
    }
}