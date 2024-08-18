using DependencyInjection.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Dependency ýnjection == service registration
builder.Services.AddTransient<MyMiddleware>();
var app = builder.Build();

//app.Use((context, next) =>
//{
//    context.Response.StatusCode = 500;
//    return next();
//});

app.MapControllers();

//app.Use((context, next) =>
//{
//    context.Response.StatusCode = 200;
//    return next();
//});

app.UseMiddleware<MyMiddleware>();

app.Run();
