using StepCounter.Core.Interface;
using StepCounter.Core.Model.Counter.DTO;
using StepCounter.Core.Model.Team;
using StepCounter.Core.Model.Team.DTO;

namespace StepCounter.Core.Service;

public class TeamService(ITeamRepository repository, ICounterService counterService) : ITeamService
{
    public async Task<Team> CreateTeamAsync()
    {
        var counter = await counterService.CreateCounterAsync();

        return await repository.CreateTeamAsync(new(Guid.NewGuid(), [], counter.Id));
    }

    public Task<Team> GetTeamAsync(Guid teamId)
        => TryGetTeamAsync(teamId);

    public async Task<Team> UpdateTeamAsync(Guid teamId, UpdateTeamRequest request)
    {
        var existingTeam = await TryGetTeamAsync(teamId);
        var newCounterIds = request.MembersCountersIds.Except(existingTeam.MembersCountersIds).ToList();
        var counters = await Task.WhenAll(newCounterIds.Select(counterService.GetCounterAsync));

        var totalSteps = counters.Sum(counter => counter.StepCount);

        var teamCounter = await counterService.GetCounterAsync(existingTeam.TeamCounterId);
        await counterService.UpdateCounterAsync(teamCounter.Id, new UpdateCounterRequest(totalSteps), false);

        var updatedTeam = await repository.UpdateTeamAsync(existingTeam with
        {
            Id = existingTeam.Id,
            MembersCountersIds = request.MembersCountersIds,
            TeamCounterId = existingTeam.TeamCounterId
        });

        return updatedTeam;
    }

    public async Task DeleteTeamAsync(Guid teamId)
    {
        var team = await TryGetTeamAsync(teamId);

        await repository.DeleteTeamAsync(team);
    }

    private async Task<Team> TryGetTeamAsync(Guid teamId)
        => await repository.GetTeamAsync(teamId) ??
           throw new KeyNotFoundException($"Team with id {teamId} not found");
}