using UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.ValidationErrors;

namespace UseCasePatternWithRichDomain.UseCases.Tests.UseCases.CreateToDo;

public class CreateToDoUseCaseOutputPort: IOutputPort
{
    public OutputPortInvokedMethod InvokedOutputMethod { get; set; }
    public Guid Id { get; set; }

    public void WriteStandard(CreateToDoOutput output)
    {
        InvokedOutputMethod = OutputPortInvokedMethod.Standard;
        Id = output.Id;
    }

    public void WriteBusinessRuleError(string message)
    {
        InvokedOutputMethod = OutputPortInvokedMethod.WriteBusinessRuleError;
    }

    public void WriteInvalidInput(List<InvalidUseCaseInputValidationError> errors)
    {
        InvokedOutputMethod = OutputPortInvokedMethod.WriteInvalidInput;
    }
}