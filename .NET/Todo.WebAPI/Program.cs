var builder = WebApplication.CreateBuilder(args);

#region Service registration
builder.Services.AddControllers(); //extensions methods
builder.Services.AddHttpContextAccessor();
#endregion

var app = builder.Build();

#region Middleware
app.MapGet("/", () => "Hello World!"); //minimal API
app.MapControllers();//extensions method
#endregion

app.Run();