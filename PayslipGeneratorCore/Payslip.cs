using System.Collections.Generic;

namespace PayslipGeneratorCore
{
    public class Payslip
    {
        public int GrossIncome { get; set; }
        public int NetIncome { get; set; }
        public int Super { get; set; }
        public int IncomeTax { get; set; }
        public string EmployeeName { get; set; }
        public string Period { get; set; }
    }
}