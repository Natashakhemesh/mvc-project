namespace mvc_project.Models
{
    public class SalaryInfo
    {
        public int Id { get; set; }
        public decimal Net { get; set; }
        public decimal Gross { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
