using PayslipProblemVer2;
using Xunit;

namespace PayslipProblemTests
{
    public class IncomeTaxCalculatorShould
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10000, 0)]
        [InlineData(18200, 0)]
        public void Return_correct_incomeTax(uint annualSalary, uint expectedIncomeTax)
        {
            var incomeTaxCalculator = new IncomeTaxCalculator();

            var actualIncomeTax = incomeTaxCalculator.Calculate(annualSalary);
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
    }

    public class IncomeTaxCalculator : IIncomeTaxCalculator
    {
        public uint Calculate(uint employeeAnnualSalary)
        {
            return 0;
        }
    }
}