using lab3.Core;

namespace lab3.Database;

using Microsoft.EntityFrameworkCore;

public class SolutionDbContext : DbContext
{
    public DbSet<Solution> Solutions { get; set; }

    public SolutionDbContext(DbContextOptions<SolutionDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Solution>().ToTable("solutions");
        modelBuilder.Entity<Solution>().HasKey(s => s.ID);
        modelBuilder.Entity<Solution>().Property(s => s.Equation).IsRequired();
        modelBuilder.Entity<Solution>().Property(s => s.Result).IsRequired();
    }
}