using UseCasePatternWithRichDomain.Infrastructure.UseCases;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

namespace UseCasePatternWithRichDomain.Api.UseCases.CreateToDo;

public static class Endpoint
{
    public static void CreateToDoEndpoint(this WebApplication app)
    {
        app.MapPost("/todo",
            async (CreateToDoRequest request, IUseCaseExecutor useCaseExecutor, CancellationToken token) =>
            {
                var useCase = new CreateToDoInput(request.Title);
                var result = (CreateToDoPresenter)await useCaseExecutor.Execute(useCase, token);
                
                return result.ViewModel;
            });
    }
}