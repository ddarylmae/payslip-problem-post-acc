using System;
using PayslipProblemVer2;
using Xunit;

namespace PayslipProblemTests
{
    public class PayslipGeneratorShould
    {
        private readonly PayslipGenerator _payslipGenerator;
        public PayslipGeneratorShould()
        {
            _payslipGenerator = new PayslipGenerator();
        }
        
        [Fact]
        public void Return_employee_name()
        {
            var employee = GetJohnDoeFake();

            var payslip = _payslipGenerator.GetPayslip(employee, GetJunePeriodFake());
            
            Assert.Contains("Name: John Doe", payslip);
        }

        [Fact]
        public void Return_pay_period()
        {
            var period = GetJunePeriodFake();

            var payslip = _payslipGenerator.GetPayslip(GetJohnDoeFake(), period);

            Assert.Contains("Pay Period: 01 June - 30 June", payslip);
        }
        
        private Employee GetJohnDoeFake()
        {
            return new Employee
            {
                Name = "John",
                Surname = "Doe"
            };
        }

        private Period GetJunePeriodFake()
        {
            return new Period
            {
                StartDate = new DateTime(2019, 6, 1),
                EndDate = new DateTime(2019, 6, 30)
            };
        }
    }
}