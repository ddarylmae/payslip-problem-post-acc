using System.Collections.Generic;

namespace PayslipGeneratorCore
{
    public class PayslipGenerator : IPayslipGenerator
    {
        private readonly Calculator _calculator;

        public PayslipGenerator(ITaxRates taxRates)
        {
            _calculator = new Calculator(taxRates);
        }

        public Payslip Generate(Employee employee, Period period)
        {
            var payslip = _calculator.CalculatePayslip(employee);
            payslip.EmployeeName = GetName(employee);
            payslip.Period = GetPeriod(period);
            
            return payslip;
        }

        private string GetPeriod(Period period)
        {
            return $"{period.StartDate} - {period.EndDate}";
        }

        private string GetName(Employee employee)
        {
            return $"{employee.Name} {employee.Surname}";
        }
    }
}