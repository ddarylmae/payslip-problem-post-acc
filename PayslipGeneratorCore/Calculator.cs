using System;

namespace PayslipGeneratorCore
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
        
        private int CalculateSuper()
        {
            var gross = CalculateGross();
            var super = gross * (_employee.SuperRate / 100.0);
            
            return RoundToInt(super);
        }
        
        private int CalculateGross()
        {
            return (int) _employee.AnnualSalary / 12;
        }
        
        private int CalculateNetIncome()
        {
            var grossIncome = CalculateGross();
            var incomeTax = CalculateTax();
            var netIncome = grossIncome - incomeTax;
            return netIncome;
        }
        
        private int CalculateTax()
        {
            var payRange = _taxRates.Get(_employee.AnnualSalary);
            var incomeTax = (payRange.Amount + (_employee.AnnualSalary - payRange.LowerLimit) * payRange.Excess) / 12.0;
            var roundedIncomeTax = RoundToInt(incomeTax);
            
            return roundedIncomeTax;
        }

        private int RoundToInt(double value)
        {
            return (int) Math.Round(value);
        }
    }
}