using Microsoft.EntityFrameworkCore;
using StepCounter.Core.Interface;
using StepCounter.Core.Model.Team;
using StepCounter.Infrastructure.PersistenceContext;

namespace StepCounter.Infrastructure.Repository;

public class TeamRepository(AppDbContext context) : ITeamRepository
{
    public async Task<Team> CreateTeamAsync(Team team)
    {
        await context.Teams.AddAsync(team);
        await context.SaveChangesAsync();
        return team;
    }

    public async Task<Team?> GetTeamAsync(Guid teamId)
        => await context.Teams.AsNoTracking().FirstOrDefaultAsync(t => t.Id == teamId);

    public async Task<Team> UpdateTeamAsync(Team team)
    {
        context.Teams.Update(team);
        await context.SaveChangesAsync();
        return team;
    }

    public async Task DeleteTeamAsync(Team team)
    {
        context.Teams.Remove(team);
        await context.SaveChangesAsync();
    }
}