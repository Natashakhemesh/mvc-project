using mvc_project.ViewComponents;
using Microsoft.AspNetCore.Mvc;
public class LeftNavigation : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var links = new List<NavLink>
        {
            new NavLink("Home", "Index","Home"),
            new NavLink("Employee", "Index","Employees"),
            new NavLink("Home", "Privacy","Privacy"),
            new NavLink("Company", "Index", "Company"),
            new NavLink("Employee", "SalaryDetails", "Salaries")

        };

        return View(links);
    }
}
