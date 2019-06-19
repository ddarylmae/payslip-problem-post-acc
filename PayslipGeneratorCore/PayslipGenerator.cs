using System.Collections.Generic;

namespace PayslipGeneratorCore
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
            
            return $"Name: {_employee.Name} {_employee.Surname} \n" +
                   $"Pay Period: {period.StartDate} - {period.EndDate} \n" +
                   $"Gross Income: {payslip.GrossIncome} \n" +
                   $"Income Tax: {payslip.IncomeTax} \n" +
                   $"Net Income: {payslip.NetIncome} \n" +
                   $"Super: {payslip.Super}";
        }

        public Payslip Generate(Employee employee, Period period)
        {
            return new Payslip
            {
                EmployeeName = $"{employee.Name} {employee.Surname}",
            };
        }
    }
}