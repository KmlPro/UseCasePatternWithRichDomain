using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Executor;
using UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

namespace UseCasePatternWithRichDomain.Api.UseCases.ChangeToDoTitle;

public static class Endpoint
{
    public static void ChangeToDoTitleEndpoint(this WebApplication app)
    {
        app.MapPost("/todo/changeTitle",
            async (ChangeToDoTitleRequest request, IUseCaseExecutor useCaseExecutor, CancellationToken token) =>
            {
                var useCase = new ChangeToDoTitleInput(request.Title, request.Id);
                var result = (ChangeToDoTitlePresenter)await useCaseExecutor.Execute(useCase, token);

                return result.ViewModel;
            });
    }
}