using System;
using System.Collections.Generic;
using System.Linq;
using PayslipProblemVer2;

namespace PayslipProblemTests
{
    public class IncomeTaxCalculator : IIncomeTaxCalculator
    {
        public uint Calculate(uint annualSalary)
        {
            var payRange = PayRange.Get(annualSalary);
            var incomeTax = (uint) Math.Round(payRange.Add + (annualSalary - payRange.LowerLimit) * payRange.Cents);
            
            return incomeTax;
        }
    }
}