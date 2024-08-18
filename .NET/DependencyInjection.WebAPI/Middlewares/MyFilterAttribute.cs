using Microsoft.AspNetCore.Mvc.Filters;

namespace DependencyInjection.WebAPI.Middlewares;

public class MyFilterAttribute : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        //işlem bittiğinde
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        //işlem başlamadan önce
    }
}


public class MyMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {

            context.Response.StatusCode = 429;
            await context.Response.WriteAsync("Something went wrong!");

        }
        catch (Exception)
        {
            await next(context);
        }
    }
}
