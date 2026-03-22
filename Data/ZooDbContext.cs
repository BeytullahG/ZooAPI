using Microsoft.EntityFrameworkCore;

public class ZooDbContext : DbContext
{
    public DbSet<Animal> Animals{get; set;} = null!;

    public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options)
    {
        
    }
}