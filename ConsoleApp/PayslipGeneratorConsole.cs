using PayslipGeneratorCore;

namespace ConsoleApp
{
    public class PayslipGeneratorConsole
    {
        private readonly IOutputWriter _outputWriter;
        private IPayslipGenerator _payslipGenerator;
        
        public PayslipGeneratorConsole(IOutputWriter outputWriter, IPayslipGenerator payslipGenerator)
        {
            _outputWriter = outputWriter;
            _payslipGenerator = payslipGenerator;
        }

        public void Run()
        {
            DisplayWelcomeMessage();
            AskForEmployeeName();
        }

        private void AskForEmployeeName()
        {
            _outputWriter.Write("Please input your name:");
        }

        private void DisplayWelcomeMessage()
        {
            _outputWriter.Write("Welcome to the payslip generator!");
        }
    }
}