namespace PayslipProblemVer2
{
    public class PayslipGenerator
    {
        public string GetPayslip(Employee employee, Period period)
        {
            return $"Name: {employee.Name} {employee.Surname} \n" +
                   $"Pay Period: {period.StartDate.ToString("dd MMMM")} - {period.EndDate.ToString("dd MMMM")}";
        }
    }
}