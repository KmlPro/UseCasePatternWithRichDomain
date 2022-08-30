namespace UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle;

public class ChangeToDoTitleOutput
{
    public ChangeToDoTitleOutput(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}