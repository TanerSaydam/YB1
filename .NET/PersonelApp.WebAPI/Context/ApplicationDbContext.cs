using Microsoft.EntityFrameworkCore;
using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Personel> Personels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnType("varchar(100)");
        //modelBuilder.Entity<Personel>().Property(p => p.FirstName).HasColumnType("varchar(50)");
        //modelBuilder.Entity<Personel>().Property(p => p.LastName).HasColumnType("varchar(50)");
        //modelBuilder.Entity<Personel>().Property(p => p.Salary).HasColumnType("money");

        modelBuilder.Entity<Personel>(builder =>
        {
            builder.Property(p => p.Id).HasColumnType("varchar(100)");
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
            builder.Property(p => p.Salary).HasColumnType("money");
        });
    }
}

