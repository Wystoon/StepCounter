using StepCounter.Core.Model.Counter;

namespace StepCounter.Core.Interface;

public interface ICounterService
{
    public Task<Counter> CreateCounterAsync();
}