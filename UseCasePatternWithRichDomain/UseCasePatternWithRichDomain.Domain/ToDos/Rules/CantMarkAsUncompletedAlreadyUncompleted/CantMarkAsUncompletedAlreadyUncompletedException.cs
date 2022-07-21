using UseCasePatternWithRichDomain.BuildingBlocks;

namespace UseCasePatternWithRichDomain.ToDos.Rules.CantMarkAsUncompletedAlreadyUncompleted;

public class CantMarkAsUncompletedAlreadyUncompletedException : BusinessRuleValidationException
{
    private const string ErrorMessage = "Cant mark as uncompleted To do item that is already completed";

    public CantMarkAsUncompletedAlreadyUncompletedException(IBusinessRule brokenRule) : base(brokenRule, ErrorMessage)
    {
    }
}