using StepCounter.Core.Interface;
using StepCounter.Core.Service;

namespace StepCounter.Api.Extension;

public static class GeneralServiceExtensions
{
    public static void AddGeneralServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICounterService, CounterService>();
        builder.Services.AddScoped<ITeamService, TeamService>();
        builder.Services.AddScoped<IGlobalScoreService, GlobalScoreService>();
    }
}