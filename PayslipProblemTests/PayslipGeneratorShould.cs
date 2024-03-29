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
            var payslip = _payslipGenerator.Generate(GetPayslipRequestFake());
            
            Assert.Equal("John Doe", payslip.EmployeeName);
        }

        [Fact]
        public void Return_pay_period()
        {
            var payslipRequest = GetPayslipRequestFake();
            payslipRequest.StartDate = "01 March";
            payslipRequest.EndDate = "31 March";
            
            var payslip = _payslipGenerator.Generate(payslipRequest);

            Assert.Equal("01 March - 31 March", payslip.Period);
        }

        [Fact]
        public void Return_gross_income()
        {
            var payslipRequest = GetPayslipRequestFake();
            payslipRequest.AnnualSalary = 60050;
            
            var payslip = _payslipGenerator.Generate(payslipRequest);
            
            Assert.Equal(5004, payslip.GrossIncome);
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
        public void Return_income_tax(uint annualSalary, int expectedIncomeTax)
        {
            var payslipRequest = GetPayslipRequestFake();
            payslipRequest.AnnualSalary = annualSalary;
            
            var payslip = _payslipGenerator.Generate(payslipRequest);
            
            Assert.Equal(expectedIncomeTax, payslip.IncomeTax);
        }

        [Theory]
        [InlineData(10000, 833)]
        [InlineData(60050, 4082)]
        public void Return_net_income(uint annualSalary, int expectedNetIncome)
        {
            var payslipRequest = GetPayslipRequestFake();
            payslipRequest.AnnualSalary = annualSalary;

            var payslip = _payslipGenerator.Generate(payslipRequest);
            
            Assert.Equal(expectedNetIncome, payslip.NetIncome);
        }

        [Theory]
        [InlineData(10000, 12, 100)]
        [InlineData(60050, 9, 450)]
        public void Return_super(uint annualSalary, double superRate, int expectedSuper)
        {
            var payslipRequest = GetPayslipRequestFake();
            payslipRequest.AnnualSalary = annualSalary;
            payslipRequest.SuperRate = superRate;
            
            var payslip = _payslipGenerator.Generate(payslipRequest);
            
            Assert.Equal(expectedSuper, payslip.Super);
        }
        
        private PayslipRequest GetPayslipRequestFake()
        {
            return new PayslipRequest
            {
                Name = "John", 
                Surname = "Doe",
                StartDate = "01 June",
                EndDate = "30 June"
            };
        }
    }
}