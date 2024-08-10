using Microsoft.EntityFrameworkCore;

namespace Todo.WebAPI.Context;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = ServiceTool.ServiceProvider.GetRequiredService<IConfiguration>();
        string connectionString = configuration.GetConnectionString("SqlServer")!;
        optionsBuilder.UseSqlServer(connectionString);
        //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    public DbSet<Models.Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Todo>().HasQueryFilter(x => x.IsDeleted == false);
    }
}
