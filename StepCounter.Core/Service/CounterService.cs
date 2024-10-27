using StepCounter.Core.Interface;
using StepCounter.Core.Model.Counter;
using StepCounter.Core.Model.Counter.DTO;

namespace StepCounter.Core.Service;

public class CounterService(ICounterRepository counterRepository, IGlobalScoreRepository globalScoreRepository)
    : ICounterService
{
    public Task<Counter> CreateCounterAsync()
        => counterRepository.AddCounterAsync(new(Guid.NewGuid(), 0));

    public async Task<Counter> UpdateCounterAsync(Guid counterId, UpdateCounterRequest request)
    {
        var existingCounter = await TryGetCounterAsync(counterId);
        var updatedCounter = await UpdateCounterAsync(existingCounter, request);

        await TryUpdateTeamCounter(existingCounter, request);

        await UpdateGlobalCounter(request);

        return updatedCounter;
    }

    private async Task<Counter> TryGetCounterAsync(Guid counterId)
        => await counterRepository.GetCounterAsync(counterId) ??
           throw new KeyNotFoundException($"Counter with id {counterId} not found");

    private async Task TryUpdateTeamCounter(Counter existingCounter, UpdateCounterRequest request)
    {
        var teamCounter = await counterRepository.GetTeamCounter(existingCounter.Id);

        if (teamCounter is not null)
            await UpdateCounterAsync(teamCounter, request);
    }

    private async Task<Counter> UpdateCounterAsync(Counter counter, UpdateCounterRequest request)
        => await counterRepository.UpdateCounterAsync(counter with
        {
            Id = counter.Id,
            StepCount = counter.StepCount + request.StepCount
        });

    private async Task UpdateGlobalCounter(UpdateCounterRequest request)
    {
        var globalScore = await globalScoreRepository.GetGlobalScoreAsync();
        var globalStepCounter = await TryGetCounterAsync(globalScore.CounterId);

        await UpdateCounterAsync(globalStepCounter, request);
    }
}