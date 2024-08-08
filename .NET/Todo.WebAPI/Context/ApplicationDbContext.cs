using Microsoft.EntityFrameworkCore;

namespace Todo.WebAPI.Context;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        HttpContextAccessor httpContextAccessor = new();
        var configuration = httpContextAccessor.HttpContext!.RequestServices.GetRequiredService<IConfiguration>();

        string connectionString = configuration.GetConnectionString("SqlServer")!;

        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Models.Todo> Todos { get; set; }
}


//class MyContext
//{
//    public object Options { get; set; }

//    public MyContext()
//    {

//    }

//    public MyContext(object options)
//    {
//        Options = options;
//    }

//    public virtual void OnConfiguring(object options)
//    {
//        //Options = options;
//    }
//}

//class AppDbContext : MyContext
//{
//    public AppDbContext(object opt) : base(opt)
//    {

//    }


//    public override void OnConfiguring(object options)
//    {
//        base.OnConfiguring(options);
//    }
//}