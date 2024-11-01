using Microsoft.EntityFrameworkCore;
using StepCounter.Core.Interface;
using StepCounter.Core.Model.Counter;
using StepCounter.Infrastructure.PersistenceContext;

namespace StepCounter.Infrastructure.Repository;

public class CounterRepository(AppDbContext context) : ICounterRepository
{
    public async Task<Counter> CreateCounterAsync(Counter counter)
    {
        await context.Counters.AddAsync(counter);
        await context.SaveChangesAsync();
        return counter;
    }

    public async Task<Counter?> GetCounterAsync(Guid counterId)
        => await context.Counters.AsNoTracking().FirstOrDefaultAsync(c => c.Id == counterId);

    public async Task<Counter> UpdateCounterAsync(Counter counter)
    {
        context.Counters.Update(counter);
        await context.SaveChangesAsync();
        return counter;
    }

    public async Task<Counter?> GetTeamCounter(Guid counterId)
    {
        var team = await context.Teams.AsNoTracking()
            .FirstOrDefaultAsync(t => t.MembersCountersIds.Contains(counterId));

        return team is null
            ? null
            : await context.Counters.AsNoTracking().FirstOrDefaultAsync(c => c.Id == team.TeamCounterId);
    }
}