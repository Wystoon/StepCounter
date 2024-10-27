using Microsoft.EntityFrameworkCore;
using StepCounter.Core.Model.Counter;
using StepCounter.Core.Model.GlobalScore;
using StepCounter.Core.Model.Team;

namespace StepCounter.Infrastructure.PersistenceContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Counter> Counters { get; set; }
    public DbSet<Team> Teams { get; set; }
    
    public DbSet<GlobalScore> GlobalScores { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var globalCounterId = Guid.NewGuid();
        modelBuilder.Entity<Counter>().HasData(new Counter(globalCounterId, 0));
        modelBuilder.Entity<GlobalScore>().HasData(new GlobalScore(Guid.NewGuid(), globalCounterId));
    }
}