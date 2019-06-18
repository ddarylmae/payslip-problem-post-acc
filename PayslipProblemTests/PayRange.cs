using System.Collections.Generic;
using System.Linq;

namespace PayslipProblemTests
{
    public class PayRange
    {
        public uint LowerLimit { get; private set; }
        public double Amount { get; private set; }
        public double Excess { get; private set; }

        private static readonly List<PayRange> PayRanges = new List<PayRange>
        {
            new PayRange {LowerLimit = 180001, Amount = 54232, Excess = 0.45},
            new PayRange {LowerLimit = 87001, Amount = 19822, Excess = 0.37},
            new PayRange {LowerLimit = 37001, Amount = 3572, Excess = 0.325},
            new PayRange {LowerLimit = 18201, Amount = 0, Excess = 0.19},
            new PayRange {LowerLimit = 0, Amount = 0, Excess = 0},
        };

        public static PayRange Get(uint annualSalary)
        {
            return PayRanges.FirstOrDefault(p => annualSalary >= p.LowerLimit);
        }
    }
}