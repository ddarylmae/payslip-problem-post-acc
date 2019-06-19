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
            _outputWriter.Write("Welcome to the payslip generator!");
        }
    }
}