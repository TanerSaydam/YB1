using eCommerceServer.Context;
using eCommerceServer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddTransient<CategoryRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();