using System;
using Moq;
using PayslipProblemVer2;
using Xunit;

namespace PayslipProblemTests
{
    public class PayslipGeneratorShould
    {
        private PayslipGenerator _payslipGenerator;
        
        [Fact]
        public void Return_employee_name()
        {
            var employee = GetJohnDoeFake();
            _payslipGenerator = new PayslipGenerator();

            var payslip = _payslipGenerator.GetPayslip(employee, GetJunePeriodFake());
            
            Assert.Contains("Name: John Doe", payslip);
        }

        [Fact]
        public void Return_pay_period()
        {
            var period = GetJunePeriodFake();
            _payslipGenerator = new PayslipGenerator();

            var payslip = _payslipGenerator.GetPayslip(GetJohnDoeFake(), period);

            Assert.Contains("Pay Period: 01 June - 30 June", payslip);
        }

        [Fact]
        public void Return_gross_income()
        {
            var employee = GetJohnDoeFake();
            employee.AnnualSalary = 60050;
            _payslipGenerator = new PayslipGenerator();

            var payslip = _payslipGenerator.GetPayslip(employee, GetJunePeriodFake());
            
            Assert.Contains("Gross Income: 5004", payslip);
        }

        [Theory]
        [InlineData(60050, 922)]
        [InlineData(80050, 1464)]
        public void Return_income_tax(uint annualSalary, uint expectedIncomeTax)
        {
            var employee = GetJohnDoeFake();
            employee.AnnualSalary = annualSalary;
            _payslipGenerator = new PayslipGenerator();
            
            var payslip = _payslipGenerator.GetPayslip(employee, GetJunePeriodFake());
            
            Assert.Contains($"Income Tax: {expectedIncomeTax}", payslip);
        }

        private Employee GetJohnDoeFake()
        {
            return new Employee
            {
                Name = "John",
                Surname = "Doe"
            };
        }

        private Period GetJunePeriodFake()
        {
            return new Period
            {
                StartDate = new DateTime(2019, 6, 1),
                EndDate = new DateTime(2019, 6, 30)
            };
        }
    }
}