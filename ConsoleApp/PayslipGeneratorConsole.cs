using System;
using PayslipGeneratorCore;

namespace ConsoleApp
{
    public class PayslipGeneratorConsole
    {
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;
        private readonly IPayslipGenerator _payslipGenerator;
        
        public PayslipGeneratorConsole(IInputReader inputReader, IOutputWriter outputWriter, IPayslipGenerator payslipGenerator)
        {
            _inputReader = inputReader;
            _outputWriter = outputWriter;
            _payslipGenerator = payslipGenerator;
        }

        public void Run()
        {
            DisplayWelcomeMessage();
            var payslipRequest = GetUserInputs();
            var payslip = ProcessPayslip(payslipRequest);
            DisplayPayslipReport(payslip);
        }

        private Payslip ProcessPayslip(PayslipRequest payslipRequest)
        {
            return _payslipGenerator.Generate(payslipRequest);
        }

        private PayslipRequest GetUserInputs()
        {
            var payslipRequest = new PayslipRequest
            {
                Name = GetName(),
                Surname = GetSurname(),
                AnnualSalary = GetAnnualSalary(),
                SuperRate = GetSuperRate(),
                StartDate = GetStartDate(),
                EndDate = GetEndDate()
            };

            return payslipRequest;
        }

        private uint GetAnnualSalary()
        {
            Display(MessageConstants.EnterAnnualSalary);
            uint.TryParse(GetInput(), out var annualSalary);
            return annualSalary;
        }

        private string GetEndDate()
        {
            Display(MessageConstants.EnterEndDate);
            return GetInput();
        }

        private string GetStartDate()
        {
            Display(MessageConstants.EnterStartDate);
            return GetInput();
        }

        private double GetSuperRate()
        {
            Display(MessageConstants.EnterSuperRate);
            Double.TryParse(GetInput(), out var superRate);
            return superRate;
        }

        private string GetSurname()
        {
            Display(MessageConstants.EnterSurname);
            return GetInput();
        }

        private string GetName()
        {
            Display(MessageConstants.EnterName);
            return GetInput();
        }

        private void DisplayPayslipReport(Payslip payslip)
        {
            Display("Your payslip has been generated:\n\n" +
                $"Name: {payslip.EmployeeName}\n" +
                $"Pay Period: {payslip.Period}\n" +
                $"Gross Income: {payslip.GrossIncome}\n" +
                $"Income Tax: {payslip.IncomeTax}\n" +
                $"Net Income: {payslip.NetIncome}\n" +
                $"Super: {payslip.Super}");
        }

        private string GetInput()
        {
            return _inputReader.Read();
        }

        private void Display(string message)
        {
            _outputWriter.Write(message);
        }

        private void DisplayWelcomeMessage()
        {
            Display(MessageConstants.Welcome);
        }
    }
}