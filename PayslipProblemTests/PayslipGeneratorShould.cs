using System;
using Moq;
using Xunit;

namespace PayslipProblemTests
{
    public class PayslipGeneratorShould
    {
        [Fact]
        public void Return_employee_name_in_payslip()
        {
            var payslipGenerator = new PayslipGenerator();
            var employee = new Employee
            {
                Name = "John",
                Surname = "Doe"
            };

            var payslip = payslipGenerator.GeneratePayslip(employee, It.IsAny<Period>());
            
            Assert.Equal("John Doe", payslip.Name);
        }
    }

    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal SuperRate { get; set; }
    }

    public class PayslipGenerator
    {
        public Payslip GeneratePayslip(Employee employee, Period period)
        {
            return new Payslip {Name = $"{employee.Name} {employee.Surname}"};
        }
    }

    public class Payslip
    {
        public string Name { get; set; }
        public string Period { get; set; }
        public int GrossIncome { get; set; }
        public int IncomeTax { get; set; }
        public int NetIncome { get; set; }
        public int Super { get; set; }
    }
}