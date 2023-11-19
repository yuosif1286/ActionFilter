using ActionFilter.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ActionFilter.ActionFilters;

public class ValidateEntityExistAttribute<T> : IActionFilter where
    T : class, IEntity
{
    private readonly IWeatherRepo _weatherRepo;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public ValidateEntityExistAttribute(IWeatherRepo weatherRepo)
    {
        _weatherRepo = weatherRepo;
    }

    public async void OnActionExecuting(ActionExecutingContext context)
    {
        Guid id = Guid.Empty;
        if (context.ActionArguments.ContainsKey("id"))
        {
            id = (Guid)context.ActionArguments["id"];
        }
        else
        {
            context.Result = new BadRequestObjectResult("Bad id parameter");
            return;
        }

        var entity = await _weatherRepo.FindById(id);
        if (entity == null)
        {
            context.Result = new NotFoundResult();
        }
        else
        {
            context.HttpContext.Items.Add("entity", entity);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var entity = (T)context.HttpContext.Items["entity"];
        
        Console.Write(entity.Id);
    }
}