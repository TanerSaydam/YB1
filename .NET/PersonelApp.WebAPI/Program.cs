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


//Tuple
//class A
//{
//    public A()
//    {
//        var person = GetPersonelInfo();

//        Console.WriteLine(@$"
//                  Name: {person.firstName}\n
//                  LastName: {person.lastName}\n
//                  Age: {person.age}");
//    }

//    public (string firstName, string lastName, int age) GetPersonelInfo()
//    {
//        return ("Taner", "Saydam", 50);
//    }
//}