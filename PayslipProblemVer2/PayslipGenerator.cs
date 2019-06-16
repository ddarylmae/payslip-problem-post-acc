namespace PayslipProblemVer2
{
    public class PayslipGenerator
    {
        public Payslip GeneratePayslip(Employee employee, Period period)
        {
            return new Payslip
            {
                Name = $"{employee.Name} {employee.Surname}",
                Period = $"{period.StartDate.ToString("dd MMMM")} - {period.EndDate.ToString("dd MMMM")}"
            };
        }
    }
}