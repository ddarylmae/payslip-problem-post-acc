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
        [InlineData(37000, 3572)]
        [InlineData(37001, 3572)]
        [InlineData(40000, 4547)]
        [InlineData(87000, 19822)]
        [InlineData(87001, 19822)]
        [InlineData(100000, 24632)]
        [InlineData(180000, 54232)]
        [InlineData(180001, 54232)]
        [InlineData(200000, 63232)]
        public void Return_correct_incomeTax(uint annualSalary, uint expectedIncomeTax)
        {
            var incomeTaxCalculator = new IncomeTaxCalculator();

            var actualIncomeTax = incomeTaxCalculator.Calculate(annualSalary);
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
    }
}