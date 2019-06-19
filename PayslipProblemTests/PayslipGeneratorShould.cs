using System;
using Moq;
using PayslipGeneratorCore;
using Xunit;

namespace PayslipProblemTests
{
    public class PayslipGeneratorShould
    {
        private readonly PayslipGenerator _payslipGenerator;

        public PayslipGeneratorShould()
        {
            _payslipGenerator = new PayslipGenerator(new TaxRates2017To2018());
        }
        
        [Fact]
        public void Return_employee_name()
        {
            var payslip = _payslipGenerator.Get(GetJohnDoeFake(), GetJunePeriodFake());
            
            Assert.Contains("Name: John Doe", payslip);
        }

        [Fact]
        public void Return_pay_period()
        {
            var period = new Period {StartDate = "01 March", EndDate = "31 March"};
            
            var payslip = _payslipGenerator.Get(GetJohnDoeFake(), period);

            Assert.Contains("Pay Period: 01 March - 31 March", payslip);
        }

        [Fact]
        public void Return_gross_income()
        {
            var employee = GetJohnDoeFake();
            employee.AnnualSalary = 60050;
            
            var payslip = _payslipGenerator.Get(employee, GetJunePeriodFake());
            
            Assert.Contains("Gross Income: 5004", payslip);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10000, 0)]
        [InlineData(18200, 0)]
        [InlineData(18201, 0)]
        [InlineData(25000, 108)]
        [InlineData(37000, 298)]
        [InlineData(37001, 298)]
        [InlineData(60050, 922)]
        [InlineData(80050, 1464)]
        [InlineData(87000, 1652)]
        [InlineData(87001, 1652)]
        [InlineData(100000, 2053)]
        [InlineData(180000, 4519)]
        [InlineData(180001, 4519)]
        [InlineData(200000, 5269)]
        public void Return_income_tax(uint annualSalary, uint expectedIncomeTax)
        {
            var employee = GetJohnDoeFake();
            employee.AnnualSalary = annualSalary;
            
            var payslip = _payslipGenerator.Get(employee, GetJunePeriodFake());
            
            Assert.Contains($"Income Tax: {expectedIncomeTax}", payslip);
        }

        [Theory]
        [InlineData(10000, 833)]
        [InlineData(60050, 4082)]
        public void Return_net_income(uint annualSalary, uint expectedNetIncome)
        {
            var employee = GetJohnDoeFake();
            employee.AnnualSalary = annualSalary;

            var payslip = _payslipGenerator.Get(employee, GetJunePeriodFake());
            
            Assert.Contains($"Net Income: {expectedNetIncome}", payslip);
        }

        [Theory]
        [InlineData(10000, 12, 100)]
        [InlineData(60050, 9, 450)]
        public void Return_super(uint annualSalary, double superRate, uint expectedSuper)
        {
            var employee = GetJohnDoeFake();
            employee.AnnualSalary = annualSalary;
            employee.SuperRate = superRate;
            
            var payslip = _payslipGenerator.Get(employee, GetJunePeriodFake());
            
            Assert.Contains($"Super: {expectedSuper}", payslip);
        }

        private Employee GetJohnDoeFake()
        {
            return new Employee { Name = "John", Surname = "Doe" };
        }

        private Period GetJunePeriodFake()
        {
            return new Period
            {
                StartDate = "01 June",
                EndDate = "30 June"
            };
        }
    }
}