
namespace Exception.WebAPI.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (System.Exception ex)
        {
            context.Response.StatusCode = 409;
            context.Response.ContentType = "application/json";// MediaTypeNames.Application.Json;


            ErrorResponse error = new(ex.Message);


            await context.Response.WriteAsync(error.ToString());
        }
    }
}
