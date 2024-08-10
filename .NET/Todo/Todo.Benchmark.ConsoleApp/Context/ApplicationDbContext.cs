using Microsoft.EntityFrameworkCore;

namespace Todo.Benchmark.ConsoleApp.Context;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        string connectionString = "Data Source=TANER\\SQLEXPRESS;Initial Catalog=TodoDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Models.Todo> Todos { get; set; }
}
