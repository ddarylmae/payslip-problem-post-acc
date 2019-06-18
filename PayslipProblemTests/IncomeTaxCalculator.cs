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
            var payRange = GetPayRange(annualSalary);
            
            var incomeTax = (uint) Math.Round((annualSalary - payRange.LowerLimit) * payRange.Cents);
            
            return incomeTax;
        }

        private PayRange GetPayRange(uint annualSalary)
        {
            var payRanges = new List<PayRange>
            {
                new PayRange {LowerLimit = 37001, Cents = 0.325},
                new PayRange {LowerLimit = 18201, Cents = 0.19},
                new PayRange {LowerLimit = 0, Cents = 0},
            };

            var range = payRanges.FirstOrDefault(p => annualSalary >= p.LowerLimit);

            return range;
        }
    }

    public class PayRange
    {
        public uint LowerLimit { get; set; }
        public double Cents { get; set; }
    }
}