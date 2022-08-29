using UseCasePatternWithRichDomain.Api.UseCases.CreateToDo;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

namespace UseCasePatternWithRichDomain.Api;

public static class PresentersConfiguration
{
    public static void AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<IOutputPort>(x => new CreateToDoPresenter());
    }
}