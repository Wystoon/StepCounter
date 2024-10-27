using StepCounter.Core.Interface;
using StepCounter.Core.Model.Counter;

namespace StepCounter.Core.Service;

public class CounterService : ICounterService
{
    public Task<Counter> CreateCounterAsync()
    {
        throw new NotImplementedException();
    }
}