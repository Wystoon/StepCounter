using StepCounter.Core.Interface;
using StepCounter.Core.Model.Counter;
using StepCounter.Core.Model.Counter.DTO;

namespace StepCounter.Core.Service;

public class CounterService(ICounterRepository counterRepository, IGlobalScoreRepository globalScoreRepository)
    : ICounterService
{
    public Task<Counter> CreateCounterAsync()
        => counterRepository.CreateCounterAsync(new(Guid.NewGuid(), 0));

    public async Task<Counter> GetCounterAsync(Guid counterId)
        => await TryGetCounterAsync(counterId);

    public async Task<Counter> UpdateCounterAsync(
        Guid counterId,
        UpdateCounterRequest request,
        bool updateGlobalCounter)
    {
        var existingCounter = await TryGetCounterAsync(counterId);
        var updatedCounter = await UpdateIndicatedCounterAsync(existingCounter, request);

        await TryUpdateTeamCounter(existingCounter, request);

        if (updateGlobalCounter)
        {
            await UpdateGlobalCounter(request);
        }

        return updatedCounter;
    }

    private async Task<Counter> TryGetCounterAsync(Guid counterId)
        => await counterRepository.GetCounterAsync(counterId) ??
           throw new KeyNotFoundException($"Counter with id {counterId} not found");

    private async Task TryUpdateTeamCounter(Counter existingCounter, UpdateCounterRequest request)
    {
        var teamCounter = await counterRepository.GetTeamCounter(existingCounter.Id);

        if (teamCounter is not null)
            await UpdateIndicatedCounterAsync(teamCounter, request);
    }

    private async Task<Counter> UpdateIndicatedCounterAsync(Counter counter, UpdateCounterRequest request)
        => await counterRepository.UpdateCounterAsync(counter with
        {
            Id = counter.Id,
            StepCount = counter.StepCount + request.StepCount
        });

    private async Task UpdateGlobalCounter(UpdateCounterRequest request)
    {
        var globalScore = await globalScoreRepository.GetGlobalScoreAsync();
        var globalStepCounter = await TryGetCounterAsync(globalScore.CounterId);

        await UpdateIndicatedCounterAsync(globalStepCounter, request);
    }
}