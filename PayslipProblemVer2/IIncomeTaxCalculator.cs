namespace PayslipProblemVer2
{
    public interface IIncomeTaxCalculator
    {
        uint Calculate(uint employeeAnnualSalary, int superRate);
    }
}