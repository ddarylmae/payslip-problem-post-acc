namespace PayslipGeneratorCore
{
    public interface IPayslipGenerator
    {
        Payslip Generate(Employee employee, Period period);
    }
}