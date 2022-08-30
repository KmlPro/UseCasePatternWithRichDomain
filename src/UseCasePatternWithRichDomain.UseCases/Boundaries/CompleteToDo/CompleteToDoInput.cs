using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo;

public class CompleteToDoInput : IUseCaseInput<IOutputPort>
{
    public CompleteToDoInput(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; }
}