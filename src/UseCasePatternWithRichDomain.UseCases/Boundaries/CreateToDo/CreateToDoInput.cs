using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

public class CreateToDoInput : IUseCaseInput<IOutputPort>
{
    public CreateToDoInput(string id)
    {
        Id = id;
    }

    public string Id { get; }
}