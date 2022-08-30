namespace UseCasePatternWithRichDomain.UseCases.Boundaries.MarkToDoAsUncompleted;

public class MarkToDoAsUncompletedOutput
{
    public MarkToDoAsUncompletedOutput(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}