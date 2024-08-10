using Todo.WebAPI;
using Todo.WebAPI.Context;

var builder = WebApplication.CreateBuilder(args);

#region Service registration
builder.Services.AddControllers(); //extensions methods
builder.Services.AddHttpContextAccessor();
builder.Services.AddServiceTool();
#endregion

//

var app = builder.Build();

#region Middleware
app.MapGet("/", () => "Hello World!"); //minimal API

app.MapGet("/seed-data", () =>
{
    ApplicationDbContext context = new();
    for (int i = 0; i < 10000; i++)
    {
        Todo.WebAPI.Models.Todo todo = new()
        {
            Work = "Work",
            DeadLine = DateOnly.MinValue
        };

        context.Add(todo);
    }

    context.SaveChanges();

    return Results.Created();
});



app.MapControllers();//extensions method
#endregion

app.Run();