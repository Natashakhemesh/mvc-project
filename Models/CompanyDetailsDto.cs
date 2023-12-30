namespace mvc_project.Models
{
    public class CompanyDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Zipcode { get; set; }
        public string FullAddress { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}
