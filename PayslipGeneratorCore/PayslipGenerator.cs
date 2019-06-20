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

        public Payslip Generate(PayslipRequest request)
        {
            var payslip = _calculator.CalculatePayslip(request);
            payslip.EmployeeName = GetName(request.Name, request.Surname);
            payslip.Period = GetPeriod(request.StartDate, request.EndDate);
            
            return payslip;
        }

        private string GetPeriod(string startDate, string endDate)
        {
            return $"{startDate} - {endDate}";
        }

        private string GetName(string name, string surname)
        {
            return $"{name} {surname}";
        }
    }
}