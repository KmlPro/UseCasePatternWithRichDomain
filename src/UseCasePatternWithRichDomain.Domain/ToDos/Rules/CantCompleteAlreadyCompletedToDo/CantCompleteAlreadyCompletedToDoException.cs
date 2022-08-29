using UseCasePatternWithRichDomain.BuildingBlocks;

namespace UseCasePatternWithRichDomain.ToDos.Rules.CantCompleteAlreadyCompletedToDo;

public class CantCompleteAlreadyCompletedToDoException : BusinessRuleValidationException
{
    private const string ErrorMessage = "Cant complete To do item that is already completed";

    public CantCompleteAlreadyCompletedToDoException(IBusinessRule businessRule) : base(businessRule, ErrorMessage)
    {
    }
}