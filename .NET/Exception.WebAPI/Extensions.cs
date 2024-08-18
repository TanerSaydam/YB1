using Exception.WebAPI.Middlewares;

namespace Exception.WebAPI;

public static class Extensions
{
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}
