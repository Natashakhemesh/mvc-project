using mvc_project.Models;
using System.ComponentModel.DataAnnotations;

namespace mvc_project.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(5)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Zipcode can only contain digits")]
        public string Zipcode { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(60)]
        public string Country { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}