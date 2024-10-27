using System.Text.Json.Serialization;
using Asp.Versioning;
using StepCounter.Api.ErrorHandling.Filter;

namespace StepCounter.Api.Extension;

public static class ApiLayerExtensions
{
    public static void AddApiLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options => { options.Filters.Add<HttpResponseExceptionFilter>(); })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: false));
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        builder.ConfigureSwagger();
    }
}