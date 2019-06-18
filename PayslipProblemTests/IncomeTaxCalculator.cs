using System;
using PayslipProblemVer2;

namespace PayslipProblemTests
{
    public class IncomeTaxCalculator : IIncomeTaxCalculator
    {
        public uint Calculate(uint annualSalary)
        {
            var payRange = PayRange.Get(annualSalary);
            var incomeTax = payRange.Amount + (annualSalary - payRange.LowerLimit) * payRange.Excess;
            var roundedIncomeTax = RoundOff(incomeTax);
            
            return roundedIncomeTax;
        }

        private uint RoundOff(double incomeTax)
        {
            return (uint) Math.Round(incomeTax);
        }
    }
}