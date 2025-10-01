using Microsoft.EntityFrameworkCore;

namespace lab2___GameStore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    public DbSet<Person> People{ get; set;}
    public DbSet<Store> Stores { get; set;}

}
