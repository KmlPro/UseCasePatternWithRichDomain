using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Executor;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

namespace UseCasePatternWithRichDomain.Api.UseCases.CompleteToDo;

public static class Endpoint
{
    public static void CompleteToDoEndpoint(this WebApplication app)
    {
        app.MapPost("/todo/complete",
            async (CompleteToDoRequest request, IUseCaseExecutor useCaseExecutor, CancellationToken token) =>
            {
                var useCase = new CompleteToDoInput(request.Id);
                var result = (CompleteToDoPresenter)await useCaseExecutor.Execute(useCase, token);

                return result.ViewModel;
            });
    }
}