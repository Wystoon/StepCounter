using StepCounter.Core.Model.Counter;
using StepCounter.Core.Model.Counter.DTO;

namespace StepCounter.Core.Interface;

public interface ICounterService
{
    Task<Counter> CreateCounterAsync();
    Task<Counter> GetCounterAsync(Guid teamId);
    Task<Counter> UpdateCounterAsync(Guid counterId, UpdateCounterRequest request, bool updateGlobalCounter = true);
}