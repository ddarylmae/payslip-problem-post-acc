using System;

namespace PayslipProblemVer2
{
    public class PayslipGenerator
    {
        private readonly Calculator _calculator;
        private Employee _employee;

        public PayslipGenerator(ITaxRates taxRates)
        {
            _calculator = new Calculator(taxRates);
        }
        
        public string Get(Employee employee, Period period)
        {
            _employee = employee;
            var payslip = _calculator.CalculatePayslip(employee);
            
            return $"{GetName()}\n" +
                   $"{GetPeriod(period)}\n" +
                   $"Gross Income: {payslip.GrossIncome}\n" +
                   $"Income Tax: {payslip.IncomeTax}\n" +
                   $"Net Income: {payslip.NetIncome}\n" +
                   $"Super: {payslip.Super}";
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