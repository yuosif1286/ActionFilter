using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter.ActionFilters;

public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}