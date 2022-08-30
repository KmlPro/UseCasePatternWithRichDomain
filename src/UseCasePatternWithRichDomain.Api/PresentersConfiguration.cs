using UseCasePatternWithRichDomain.Api.UseCases.ChangeToDoTitle;
using UseCasePatternWithRichDomain.Api.UseCases.CompleteToDo;
using UseCasePatternWithRichDomain.Api.UseCases.CreateToDo;
using UseCasePatternWithRichDomain.Api.UseCases.MarkToDoAsUncompleted;
using ICreateToDoOutputPort = UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo.IOutputPort;
using ICompleteToDoOutputPort = UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo.IOutputPort;
using IMarkToDoAsUncompletedOutputPort = UseCasePatternWithRichDomain.UseCases.Boundaries.MarkToDoAsUncompleted.IOutputPort;
using IChangeToDoTitleOutputPort = UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle.IOutputPort;

namespace UseCasePatternWithRichDomain.Api;

public static class PresentersConfiguration
{
    public static void AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateToDoOutputPort>(x => new CreateToDoPresenter());
        services.AddScoped<ICompleteToDoOutputPort>(x => new CompleteToDoPresenter());
        services.AddScoped<IChangeToDoTitleOutputPort>(x => new ChangeToDoTitlePresenter());
        services.AddScoped<IMarkToDoAsUncompletedOutputPort>(x => new MarkToDoAsUncompletedPresenter());
    }
}