using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle;

public class ChangeToDoTitleInput : IUseCaseInput<IOutputPort>
{
    public ChangeToDoTitleInput(string title)
    {
        Title = title;
    }

    public string Title { get; }
}