using System;
using PayslipProblemVer2;

namespace PayslipProblemVer2
{
    public class IncomeTaxCalculator
    {
        private readonly ITaxRates _taxRates;
        public IncomeTaxCalculator(ITaxRates taxRates)
        {
            _taxRates = taxRates;
        }
        
        public uint Calculate(uint annualSalary)
        {
            var payRange = _taxRates.Get(annualSalary);
            var incomeTax = (payRange.Amount + (annualSalary - payRange.LowerLimit) * payRange.Excess) / 12.0;
            var roundedIncomeTax = RoundOff(incomeTax);
            
            return roundedIncomeTax;
        }

        private uint RoundOff(double incomeTax)
        {
            return (uint) Math.Round(incomeTax);
        }
    }
}