using UseCasePatternWithRichDomain.Api;
using UseCasePatternWithRichDomain.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddPresenters();

var app = builder.Build();

app.Run();