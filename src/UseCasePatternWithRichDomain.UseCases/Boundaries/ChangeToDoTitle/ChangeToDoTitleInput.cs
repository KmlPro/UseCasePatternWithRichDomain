using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle;

public class ChangeToDoTitleInput : IUseCaseInput<IOutputPort>
{
    public ChangeToDoTitleInput(string title, Guid id)
    {
        Title = title;
        Id = id;
    }

    public string Title { get; }
    public Guid Id { get; }
}