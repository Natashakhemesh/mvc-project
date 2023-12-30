using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_project.Models;
namespace mvc_project.Controllers
{
    [ServiceFilter(typeof(CustomFilter))]
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        public IActionResult SalaryDetails()
        {
            ViewBag.Layout = "_Lab2Layout";
            var employeeSalaries = _context.Employees
            .Include(e => e.Company)
            .Include(e => e.SalaryInfo)
            .Select(e => new EmployeeSalaryDto
            {
                  Id = e.Id,
                  FullName = $"{e.Name} {e.Surname}",
                  CompanyName = e.Company.Name,
                  NetSalary = e.SalaryInfo.Net,
                  GrossSalary = e.SalaryInfo.Gross
            })
            .ToList();

            return View(employeeSalaries);
        }

        public IActionResult Index()
        {
            ViewBag.Layout = "_Lab2Layout";
            using var context = new EmployeeContext();
            var employees = context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Details(int id = 1)
        {
            ViewBag.Layout = "_Lab2Layout";
            using var context = new EmployeeContext();
            var employee = context.Employees.FirstOrDefault(m => m.Id == id);
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            using var context = new EmployeeContext();
            var employee = context.Employees.FirstOrDefault(m => m.Id == id);
            return View(employee);

        }
        [HttpPost]
        public IActionResult Edit([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                // Handle validation errors
                return BadRequest(ModelState);
            }

            // Your edit logic here

            return Ok(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                // Handle validation errors
                return BadRequest(ModelState);
            }

            // Your create logic here

            return Ok(employee);
        }

    }
}
