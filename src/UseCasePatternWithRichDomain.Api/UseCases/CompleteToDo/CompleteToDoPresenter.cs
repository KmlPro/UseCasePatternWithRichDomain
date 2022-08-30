using UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo;

namespace UseCasePatternWithRichDomain.Api.UseCases.CompleteToDo;

public class CompleteToDoPresenter : IOutputPort
{
    public IResult ViewModel { get; private set; } = Results.NoContent();

    public void WriteBusinessRuleError(string message)
    {
        ViewModel = Results.UnprocessableEntity(message);
    }

    public void WriteStandard(CompleteToDoOutput output)
    {
        ViewModel = Results.Ok(output.Id);
    }
}