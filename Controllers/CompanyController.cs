using Microsoft.AspNetCore.Mvc;
using mvc_project.Models;

namespace mvc_project.Controllers
{
    public class CompanyController : Controller
    {
        private readonly EmployeeContext _context;

        public CompanyController(EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var companyDetailsList = _context.Companies
                .GroupJoin(
                    _context.Employees,
                    company => company.Id,
                    employee => employee.CompanyId,
                    (company, employees) => new CompanyDetailsDto
                    {
                        Id = company.Id,
                        Name = company.Name,
                        Zipcode = company.Zipcode,
                        FullAddress = $"{company.City}, {company.Country}",
                        NumberOfEmployees = employees.Count()
                    })
                .ToList();

            return View(companyDetailsList);
        }

    }
}
