using System.Collections.Generic;

namespace PayslipGeneratorCore
{
    public class Payslip
    {
        public uint GrossIncome { get; set; }
        public uint NetIncome { get; set; }
        public uint Super { get; set; }
        public uint IncomeTax { get; set; }
        public string EmployeeName { get; set; }
    }
}