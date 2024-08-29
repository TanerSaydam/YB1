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
builder.Services.AddCors();
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//        //policy.WithHeaders("Authorization", "MyKey");
//        //policy.WithMethods("GET", "POST");
//        //policy.WithOrigins("http://localhost:4200", "sadasd");
//        policy.AllowAnyHeader();
//        policy.AllowAnyMethod();
//        //policy.AllowAnyOrigin();
//        policy.SetIsOriginAllowed(_ => true);
//        policy.AllowCredentials();
//        //signalR => websocket
//    });
//});

builder.Services.AddControllers();

var app = builder.Build();

//app.UseCors();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    ApplicationDbContext context = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.Run();