using UseCasePatternWithRichDomain.Api.UseCases.ChangeToDoTitle;
using UseCasePatternWithRichDomain.Api.UseCases.CompleteToDo;
using UseCasePatternWithRichDomain.Api.UseCases.CreateToDo;
using UseCasePatternWithRichDomain.Api.UseCases.MarkToDoAsUncompleted;

namespace UseCasePatternWithRichDomain.Api;

public static class EndpointsConfiguration
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.CreateToDoEndpoint();
        app.CompleteToDoEndpoint();
        app.MarkToDoAsUncompletedEndpoint();
        app.ChangeToDoTitleEndpoint();
    }
}