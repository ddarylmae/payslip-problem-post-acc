namespace PayslipGeneratorCore
{
    public class PayslipRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint AnnualSalary { get; set; }
        public double SuperRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}