using Microsoft.EntityFrameworkCore;
using StepCounter.Core.Model.Counter;

namespace StepCounter.Infrastructure.DbContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Counter> Counters { get; set; }
}