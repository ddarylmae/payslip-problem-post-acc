using System;

namespace PayslipProblemVer2
{
    public class Calculator
    {
        private Employee _employee;
        private readonly ITaxRates _taxRates;
        
        public Calculator(ITaxRates taxRates)
        {
            _taxRates = taxRates;
        }

        public Payslip CalculatePayslip(Employee employee)
        {
            _employee = employee;
            return new Payslip
            {
                GrossIncome = CalculateGross(),
                IncomeTax = CalculateTax(),
                NetIncome = CalculateNetIncome(),
                Super = CalculateSuper(),
            };
        }
        
        private uint CalculateSuper()
        {
            var gross = CalculateGross();
            var super = gross * (_employee.SuperRate / 100.0);
            
            return RoundToInt(super);
        }
        
        private uint CalculateGross()
        {
            return _employee.AnnualSalary / 12;
        }
        
        private uint CalculateNetIncome()
        {
            var grossIncome = CalculateGross();
            var incomeTax = CalculateTax();
            var netIncome = grossIncome - incomeTax;
            return netIncome;
        }
        
        private uint CalculateTax()
        {
            var payRange = _taxRates.Get(_employee.AnnualSalary);
            var incomeTax = (payRange.Amount + (_employee.AnnualSalary - payRange.LowerLimit) * payRange.Excess) / 12.0;
            var roundedIncomeTax = RoundToInt(incomeTax);
            
            return roundedIncomeTax;
        }

        private uint RoundToInt(double value)
        {
            return (uint) Math.Round(value);
        }
    }
}