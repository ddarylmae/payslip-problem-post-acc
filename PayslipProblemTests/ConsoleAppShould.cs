using ConsoleApp;
using Moq;
using PayslipGeneratorCore;
using Xunit;

namespace PayslipProblemTests
{
    public class ConsoleAppShould
    {
        private readonly Mock<IInputReader> _mockInputReader;
        private readonly Mock<IOutputWriter> _mockOutputWriter;
        private readonly Mock<IPayslipGenerator> _mockPayslipGenerator;

        public ConsoleAppShould()
        {
            _mockInputReader = new Mock<IInputReader>();
            _mockOutputWriter = new Mock<IOutputWriter>();
            _mockPayslipGenerator = new Mock<IPayslipGenerator>();
        }
        
        [Fact]
        public void Display_welcome_message()
        {
            var payslipConsoleApp = new PayslipGeneratorConsole(_mockInputReader.Object, _mockOutputWriter.Object, _mockPayslipGenerator.Object);

            payslipConsoleApp.Run();
            
            _mockOutputWriter.Verify(x => x.Write("Welcome to the payslip generator!"));
        }
        
        [Fact]
        public void Ask_for_employee_name_input()
        {
            var payslipConsoleApp = new PayslipGeneratorConsole(_mockInputReader.Object, _mockOutputWriter.Object, _mockPayslipGenerator.Object);

            payslipConsoleApp.Run();
            
            _mockOutputWriter.Verify(x => x.Write("Please input your name:"));
            _mockInputReader.Verify(x => x.Read(), Times.Once);
        }
    }
}