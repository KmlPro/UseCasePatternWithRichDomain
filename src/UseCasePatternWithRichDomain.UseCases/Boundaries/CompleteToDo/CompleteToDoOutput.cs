namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo;

public class CompleteToDoOutput
{
    public CompleteToDoOutput(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}