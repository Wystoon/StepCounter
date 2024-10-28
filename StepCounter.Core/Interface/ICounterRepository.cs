using StepCounter.Core.Model.Counter;

namespace StepCounter.Core.Interface;

public interface ICounterRepository
{
    Task<Counter> CreateCounterAsync(Counter counter);
    Task<Counter?> GetCounterAsync(Guid counterId);
    Task<Counter> UpdateCounterAsync(Counter counterToBeUpdated);
    Task<Counter?> GetTeamCounter(Guid counterId);
}