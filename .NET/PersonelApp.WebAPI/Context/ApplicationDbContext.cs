using Microsoft.EntityFrameworkCore;
using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Personel> Personels { get; set; }
}
