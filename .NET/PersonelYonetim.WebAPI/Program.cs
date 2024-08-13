using Microsoft.EntityFrameworkCore;
using PersonelYonetim.WebAPI.Context;

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

app.UseStaticFiles();

app.MapControllers();

app.Run();