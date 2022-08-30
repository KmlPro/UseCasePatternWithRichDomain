using UseCasePatternWithRichDomain.Api.UseCases.CompleteToDo;
using UseCasePatternWithRichDomain.Api.UseCases.CreateToDo;

namespace UseCasePatternWithRichDomain.Api;

public static class EndpointsConfiguration
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.CreateToDoEndpoint();
        app.CompleteToDoEndpoint();
    }
}