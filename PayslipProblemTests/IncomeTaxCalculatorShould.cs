using Xunit;

namespace PayslipProblemTests
{
    public class IncomeTaxCalculatorShould
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10000, 0)]
        [InlineData(18200, 0)]
        [InlineData(18201, 0)]
        [InlineData(25000, 1292)]
        public void Return_correct_incomeTax(uint annualSalary, uint expectedIncomeTax)
        {
            var incomeTaxCalculator = new IncomeTaxCalculator();

            var actualIncomeTax = incomeTaxCalculator.Calculate(annualSalary);
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
    }
}