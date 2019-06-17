using System;
using Moq;
using PayslipProblemVer2;
using Xunit;

namespace PayslipProblemTests
{
    public class PayslipGeneratorShould
    {
        [Fact]
        public void Return_employee_name()
        {
            var payslipGenerator = new PayslipGenerator();
            var employee = new Employee
            {
                Name = "John",
                Surname = "Doe"
            };

            var payslip = payslipGenerator.GeneratePayslip(employee, new Period());
            
            Assert.Equal("John Doe", payslip.Name);
        }

        [Fact]
        public void Return_pay_period()
        {
            var payslipGenerator = new PayslipGenerator();
            var period = new Period
            {
                StartDate = new DateTime(2019, 6, 1),
                EndDate = new DateTime(2019, 6, 30),
            };

            var payslip = payslipGenerator.GeneratePayslip(new Employee(), period);
            
            Assert.Equal("01 June - 30 June", payslip.Period);
        }
        
    }
}