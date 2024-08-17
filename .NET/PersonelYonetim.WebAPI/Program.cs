using Microsoft.EntityFrameworkCore;
using PersonelYonetim.WebAPI.Context;
using PersonelYonetim.WebAPI.Repositories;
using PersonelYonetim.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

#region Service Registration
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    string connectionString = builder.Configuration.GetConnectionString("SqlServer")!;
    option.UseSqlServer(connectionString);
});

builder.Services.AddTransient<EmployeeService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeEFCoreRepository>();
builder.Services.AddTransient<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
#endregion


var app = builder.Build();

#region Middleware
app.UseSwagger();

app.UseSwaggerUI();

app.UseStaticFiles();

app.MapControllers();

app.Run();
#endregion
