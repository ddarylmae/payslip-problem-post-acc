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
            ProcessPayslip(payslipRequest);
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
            uint.TryParse(GetInput("annual salary"), out var annualSalary);
            return annualSalary;
        }

        private string GetEndDate()
        {
            return GetInput("payment end date");
        }

        private string GetStartDate()
        {
            return GetInput("payment start date");
        }

        private double GetSuperRate()
        {
            Double.TryParse(GetInput("super rate"), out var superRate);
            return superRate;
        }

        private string GetSurname()
        {
            return GetInput("surname");
        }

        private string GetName()
        {
            return GetInput("name");
        }

        private void ProcessPayslip(PayslipRequest request)
        {
            var payslip = _payslipGenerator.Generate(request);
            Output("Your payslip has been generated:\n\n"+
                $"Name: {payslip.EmployeeName}\n" +
                $"Pay Period: {payslip.Period}\n" +
                $"Gross Income: {payslip.GrossIncome}\n" +
                $"Income Tax: {payslip.IncomeTax}\n" +
                $"Net Income: {payslip.NetIncome}\n" +
                $"Super: {payslip.Super}");
        }

        private string GetInput(string requestedInput)
        {
            Output($"Please enter your {requestedInput}: ");
            var userInput = _inputReader.Read();
            return userInput;
        }

        private void Output(string message)
        {
            _outputWriter.Write(message);
        }

        private void DisplayWelcomeMessage()
        {
            Output("Welcome to the payslip generator!");
        }
    }
}