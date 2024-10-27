using StepCounter.Core.Model.Counter;

namespace StepCounter.Core.Interface;

public interface ICounterRepository
{
    Task<Counter> AddCounterAsync(Counter counter);
}