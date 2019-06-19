namespace PayslipGeneratorCore
{
    public interface ITaxRates
    {
        Range Get(uint annualSalary);
    }
}