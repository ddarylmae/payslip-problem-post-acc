using System;
using PayslipProblemVer2;

namespace PayslipProblemVer2
{
    public class IncomeTaxCalculator
    {
        public uint Calculate(uint annualSalary)
        {
            var payRange = PayRange.Get(annualSalary);
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