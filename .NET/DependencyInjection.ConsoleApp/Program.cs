
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        services.AddMyDI();


        var srv = services.BuildServiceProvider();
        var todo = srv.GetRequiredService<ITodo>();

        todo.Name = "Taner Saydam";

        var newTest = srv.GetRequiredService<NewTest>();




        int x = 0;
        List<string> names = new() { "Taner" };

    }
}

static class Extensions
{
    public static IServiceCollection AddMyDI(this IServiceCollection services)
    {
        services.AddScoped<ITodo, Todo2>();
        services.AddTransient<NewTest>();

        return services;
    }
}

interface ITodo
{
    string Name { get; set; }
}

class Todo : ITodo
{
    public string Name { get; set; }
    public Todo()
    {
        Name = "No Name";
        Console.WriteLine("Ben oluşturuldum");
    }
}

class Todo2 : ITodo
{
    public string Name { get; set; }
    public Todo2()
    {
        Name = "No Name";
        Console.WriteLine("Ben oluşturuldum");
    }
}
class NewTest
{
    public NewTest(ITodo todo)
    {
        Console.WriteLine("My name is: " + todo.Name);
    }

}