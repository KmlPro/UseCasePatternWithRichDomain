using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

public class CreateToDoInput : IUseCaseInput<IOutputPort>
{
    public CreateToDoInput(string title)
    {
        Title = title;
    }

    public string Title { get; }
}