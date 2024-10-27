using StepCounter.Core.Interface;
using StepCounter.Core.Model.Counter;
using StepCounter.Infrastructure.DbContext;

namespace StepCounter.Infrastructure.Repository;

public class CounterRepository(AppDbContext context) : ICounterRepository
{
    public async Task<Counter> AddCounterAsync(Counter counter)
    {
        context.Counters.Add(counter);
        await context.SaveChangesAsync();
        return counter;
    }
}