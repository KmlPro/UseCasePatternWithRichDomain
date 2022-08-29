using UseCasePatternWithRichDomain.BuildingBlocks;

namespace UseCasePatternWithRichDomain.ToDos.Rules.CantCompleteAlreadyCompletedToDo;

public class CantCompleteAlreadyCompletedToDoRule : IBusinessRule
{
    private readonly bool _isCompleted;
    
    public CantCompleteAlreadyCompletedToDoRule(bool isCompleted)
    {
        _isCompleted = isCompleted;
    }
    
    public void CheckIsBroken()
    {
        if (_isCompleted)
        {
            throw new CantCompleteAlreadyCompletedToDoException(this);
        }
    }
}