using Microsoft.AspNetCore.Diagnostics;

namespace Exception.WebAPI.Middlewares;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, System.Exception ex, CancellationToken cancellationToken)
    {
        context.Response.StatusCode = 409;//conflict
        context.Response.ContentType = "application/json";// MediaTypeNames.Application.Json;


        if (ex.GetType() == typeof(ArgumentException))
        {
            context.Response.StatusCode = 422;//
        }

        Result<string> result = Result<string>.Failure(ex.Message);

        await context.Response.WriteAsync(result.ToString());
        return true;
    }
}
