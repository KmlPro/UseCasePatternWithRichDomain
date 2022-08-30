using UseCasePatternWithRichDomain.UseCases.Boundaries.MarkToDoAsUncompleted;

namespace UseCasePatternWithRichDomain.Api.UseCases.MarkToDoAsUncompleted;

public class MarkToDoAsUncompletedPresenter : IOutputPort
{
    public IResult ViewModel { get; private set; } = Results.NoContent();

    public void WriteBusinessRuleError(string message)
    {
        ViewModel = Results.UnprocessableEntity(message);
    }

    public void WriteStandard(MarkToDoAsUncompletedOutput output)
    {
        ViewModel = Results.Ok(output.Id);
    }
}