using UseCasePatternWithRichDomain.Api;
using UseCasePatternWithRichDomain.Infrastructure;
using UseCasePatternWithRichDomain.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddPresenters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
DatabaseCreator.CreateDatabaseSchema(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.RegisterEndpoints();

app.Run();