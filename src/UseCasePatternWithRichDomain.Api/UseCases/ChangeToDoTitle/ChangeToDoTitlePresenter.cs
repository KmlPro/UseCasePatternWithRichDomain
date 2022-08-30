using UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.ValidationErrors;

namespace UseCasePatternWithRichDomain.Api.UseCases.ChangeToDoTitle;

public class ChangeToDoTitlePresenter : IOutputPort
{
    public IResult ViewModel { get; private set; } = Results.NoContent();

    public void WriteInvalidInput(List<InvalidUseCaseInputValidationError> errors)
    {
        ViewModel = Results.BadRequest(errors);
    }

    public void WriteBusinessRuleError(string message)
    {
        ViewModel = Results.UnprocessableEntity(message);
    }

    public void WriteStandard(ChangeToDoTitleOutput output)
    {
        ViewModel = Results.Ok(output.Id);
    }
}