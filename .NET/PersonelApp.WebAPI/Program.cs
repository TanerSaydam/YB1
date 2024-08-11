using Microsoft.EntityFrameworkCore;
using PersonelApp.WebAPI.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    string connectionString = builder.Configuration.GetConnectionString("SqlServer")!;
    option.UseSqlServer(connectionString);
});

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
//IoC container
//Inversion Of Control