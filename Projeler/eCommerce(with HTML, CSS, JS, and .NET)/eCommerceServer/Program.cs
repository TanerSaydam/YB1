using eCommerceServer.Context;
using eCommerceServer.Repositories;
using eCommerceServer.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<CategoryService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    ApplicationDbContext context = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.Run();