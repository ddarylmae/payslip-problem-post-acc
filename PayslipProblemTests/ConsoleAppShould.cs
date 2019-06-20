using System;
using System.IO;
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
        public void Get_user_input()
        {
            var payslip = GetPayslipFake();
            _mockPayslipGenerator.Setup(x => x.Generate(It.IsAny<PayslipRequest>())).Returns(payslip);
            var payslipConsoleApp = new PayslipGeneratorConsole(_mockInputReader.Object, _mockOutputWriter.Object, _mockPayslipGenerator.Object);
            
            payslipConsoleApp.Run();
            
            _mockOutputWriter.Verify(x => x.Write("Please enter your name: "));
            _mockOutputWriter.Verify(x => x.Write("Please enter your surname: "));
            _mockOutputWriter.Verify(x => x.Write("Please enter your payment start date: "));
            _mockOutputWriter.Verify(x => x.Write("Please enter your payment end date: "));
            _mockOutputWriter.Verify(x => x.Write("Please enter your annual salary: "));
            _mockOutputWriter.Verify(x => x.Write("Please enter your super rate: "));
            _mockInputReader.Verify(x => x.Read(), Times.Exactly(6));
        }
        
        [Fact]
        public void Display_payslip_from_generator()
        {
            var payslip = GetPayslipFake();
            var expectedOutput = GetContent("payslip-output.txt");
            _mockPayslipGenerator.Setup(x => x.Generate(It.IsAny<PayslipRequest>())).Returns(payslip);
            var payslipConsoleApp = new PayslipGeneratorConsole(_mockInputReader.Object, _mockOutputWriter.Object, _mockPayslipGenerator.Object);
            
            payslipConsoleApp.Run();
            
            _mockOutputWriter.Verify(x => x.Write(expectedOutput));
        }

        private Payslip GetPayslipFake()
        {
            return new Payslip
            {
                EmployeeName = "Jane Doe",
                Period = "01 March – 31 March",
                IncomeTax = 922,
                GrossIncome = 5004,
                NetIncome = 4082,
                Super = 450
            };
        }

        private string GetContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}