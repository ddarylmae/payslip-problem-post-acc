namespace PayslipGeneratorCore
{
    public interface IPayslipGenerator
    {
        Payslip Generate(PayslipRequest request);
    }
}