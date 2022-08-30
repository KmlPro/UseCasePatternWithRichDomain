using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.MarkToDoAsUncompleted;

public class MarkToDoAsUncompletedInput : IUseCaseInput<IOutputPort>
{
    public MarkToDoAsUncompletedInput(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; }
}