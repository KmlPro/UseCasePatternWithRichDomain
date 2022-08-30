using UseCasePatternWithRichDomain.Api.UseCases.CompleteToDo;
using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Executor;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo;
using UseCasePatternWithRichDomain.UseCases.Boundaries.MarkToDoAsUncompleted;

namespace UseCasePatternWithRichDomain.Api.UseCases.MarkToDoAsUncompleted;

public static class Endpoint
{
    public static void CompleteToDoEndpoint(this WebApplication app)
    {
        app.MapPost("/todo/markAsUncompleted",
            async (MarkToDoAsUncompletedRequest request, IUseCaseExecutor useCaseExecutor, CancellationToken token) =>
            {
                var useCase = new MarkToDoAsUncompletedInput(request.Id);
                var result = (MarkToDoAsUncompletedPresenter)await useCaseExecutor.Execute(useCase, token);

                return result.ViewModel;
            });
    }
}