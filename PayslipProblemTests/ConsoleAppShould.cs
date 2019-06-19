using Moq;
using PayslipGeneratorConsole;
using PayslipGeneratorCore;
using Xunit;

namespace PayslipProblemTests
{
    public class ConsoleAppShould
    {
        private readonly Mock<IOutputWriter> _mockOutputWriter;
        private readonly Mock<IPayslipGenerator> _mockPayslipGenerator;

        public ConsoleAppShould()
        {
            _mockOutputWriter = new Mock<IOutputWriter>();
            _mockPayslipGenerator = new Mock<IPayslipGenerator>();
        }
        
        [Fact]
        public void Display_welcome_message()
        {
            var payslipConsoleApp = new PayslipGeneratorConsole(_mockOutputWriter.Object, _mockPayslipGenerator.Object);

            payslipConsoleApp.Run();
            
            _mockOutputWriter.Verify(x => x.Write("Welcome to the payslip generator!"));
        }
    }
}