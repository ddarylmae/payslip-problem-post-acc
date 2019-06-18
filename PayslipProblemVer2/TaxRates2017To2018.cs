using System.Collections.Generic;
using System.Linq;

namespace PayslipProblemVer2
{
    public class TaxRates2017To2018 : ITaxRates
    {
        private readonly List<Range> _payRanges = new List<Range>
        {
            new Range {LowerLimit = 180001, Amount = 54232, Excess = 0.45},
            new Range {LowerLimit = 87001, Amount = 19822, Excess = 0.37},
            new Range {LowerLimit = 37001, Amount = 3572, Excess = 0.325},
            new Range {LowerLimit = 18201, Amount = 0, Excess = 0.19},
            new Range {LowerLimit = 0, Amount = 0, Excess = 0},
        };
        
        public Range Get(uint annualSalary)
        {
            return _payRanges.FirstOrDefault(p => annualSalary >= p.LowerLimit);
        }
    }
}