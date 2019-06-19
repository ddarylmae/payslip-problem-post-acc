using PayslipGeneratorCore;

namespace ConsoleApp
{
    public class PayslipGeneratorConsole
    {
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;
        private IPayslipGenerator _payslipGenerator;
        
        public PayslipGeneratorConsole(IInputReader inputReader, IOutputWriter outputWriter, IPayslipGenerator payslipGenerator)
        {
            _inputReader = inputReader;
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
            _inputReader.Read();
        }

        private void DisplayWelcomeMessage()
        {
            _outputWriter.Write("Welcome to the payslip generator!");
        }
    }
}