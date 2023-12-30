using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using mvc_project.Models;

public class CustomFilter : IActionFilter, IExceptionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.TryGetValue("employee", out var employee))
        {
            if (employee is Employee emp)
            {
                if (string.IsNullOrEmpty(emp.Name) || string.IsNullOrEmpty(emp.Surname))
                {
                    context.ModelState.AddModelError(string.Empty, "Name and Surname are required.");
                }
            }
        }

        context.HttpContext.Response.Headers.Add("X-Disable-Client-Side-Validation", "true");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnException(ExceptionContext context)
    {
        context.Result = new ObjectResult($"An error occurred: {context.Exception.Message}")
        {
            StatusCode = 500,
        };

        context.ExceptionHandled = true;
    }
}
