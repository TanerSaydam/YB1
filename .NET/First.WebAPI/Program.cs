var builder = WebApplication.CreateBuilder(args);
//Service Registration

//Dependency Injection

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

var app = builder.Build();
//Middleware

app.MapGet("/taner", () => "Hello Taner, How are you?");

app.MapControllers();

app.Run();