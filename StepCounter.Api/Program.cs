using Microsoft.EntityFrameworkCore;
using StepCounter.Api.Extension;
using StepCounter.Infrastructure.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.AddGeneralServices();
builder.AddApiLayer();
builder.AddInfrastructureLayer();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();
app.UseSwaggerUiWithVersioning();

app.Run();