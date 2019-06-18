using System;
using Moq;
using PayslipProblemVer2;
using Xunit;

namespace PayslipProblemTests
{
    public class PayslipGeneratorShould
    {
        private PayslipGenerator _payslipGenerator;
        private readonly Mock<IIncomeTaxCalculator> _mockIncomeTaxCalculator;
        
        public PayslipGeneratorShould()
        {
            _mockIncomeTaxCalculator = new Mock<IIncomeTaxCalculator>();
        }
        
        [Fact]
        public void Return_employee_name()
        {
            var employee = GetJohnDoeFake();
            _payslipGenerator = new PayslipGenerator(_mockIncomeTaxCalculator.Object);

            var payslip = _payslipGenerator.GetPayslip(employee, GetJunePeriodFake());
            
            Assert.Contains("Name: John Doe", payslip);
        }

        [Fact]
        public void Return_pay_period()
        {
            var period = GetJunePeriodFake();
            _payslipGenerator = new PayslipGenerator(_mockIncomeTaxCalculator.Object);

            var payslip = _payslipGenerator.GetPayslip(GetJohnDoeFake(), period);

            Assert.Contains("Pay Period: 01 June - 30 June", payslip);
        }

        [Fact]
        public void Return_gross_income()
        {
            var employee = GetJohnDoeFake();
            employee.AnnualSalary = 60050;
            _payslipGenerator = new PayslipGenerator(_mockIncomeTaxCalculator.Object);

            var payslip = _payslipGenerator.GetPayslip(employee, GetJunePeriodFake());
            
            Assert.Contains("Gross Income: 5004", payslip);
        }

        [Fact]
        public void Return_income_tax()
        {
            var employee = GetJohnDoeFake();
            _mockIncomeTaxCalculator.Setup(x => x.Calculate(It.IsAny<uint>())).Returns(922);
            _payslipGenerator = new PayslipGenerator(_mockIncomeTaxCalculator.Object);
            
            var payslip = _payslipGenerator.GetPayslip(employee, GetJunePeriodFake());
            
            Assert.Contains("Income Tax: 922", payslip);
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