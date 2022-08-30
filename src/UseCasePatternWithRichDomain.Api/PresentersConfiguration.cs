using UseCasePatternWithRichDomain.Api.UseCases.CompleteToDo;
using UseCasePatternWithRichDomain.Api.UseCases.CreateToDo;
using ICreateToDoOutputPort = UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo.IOutputPort;
using ICompleteToDoOutputPort = UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo.IOutputPort;

namespace UseCasePatternWithRichDomain.Api;

public static class PresentersConfiguration
{
    public static void AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateToDoOutputPort>(x => new CreateToDoPresenter());
        services.AddScoped<ICompleteToDoOutputPort>(x => new CompleteToDoPresenter());
    }
}