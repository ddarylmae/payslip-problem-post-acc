using System.Collections.Generic;
using System.Linq;

namespace PayslipProblemVer2
{
    public class PayRange
    {
        public uint LowerLimit { get; set; }
        public double Amount { get; set; }
        public double Excess { get; set; }
    }

    public class TaxRates2017To2018 : ITaxRates
    {
        private readonly List<PayRange> _payRanges = new List<PayRange>
        {
            new PayRange {LowerLimit = 180001, Amount = 54232, Excess = 0.45},
            new PayRange {LowerLimit = 87001, Amount = 19822, Excess = 0.37},
            new PayRange {LowerLimit = 37001, Amount = 3572, Excess = 0.325},
            new PayRange {LowerLimit = 18201, Amount = 0, Excess = 0.19},
            new PayRange {LowerLimit = 0, Amount = 0, Excess = 0},
        };
        
        public PayRange Get(uint annualSalary)
        {
            return _payRanges.FirstOrDefault(p => annualSalary >= p.LowerLimit);
        }
    }

    public interface ITaxRates
    {
        PayRange Get(uint annualSalary);
    }
}