using System.Collections.Generic;
using System.Linq;

namespace PayslipProblemTests
{
    public class PayRange
    {
        public uint LowerLimit { get; private set; }
        public double Add { get; private set; }
        public double Cents { get; private set; }

        private static readonly List<PayRange> PayRanges = new List<PayRange>
        {
            new PayRange {LowerLimit = 37001, Add = 3572, Cents = 0.325},
            new PayRange {LowerLimit = 18201, Add = 0, Cents = 0.19},
            new PayRange {LowerLimit = 0, Add = 0, Cents = 0},
        };

        public static PayRange Get(uint annualSalary)
        {
            return PayRanges.FirstOrDefault(p => annualSalary >= p.LowerLimit);
        }
    }
}