namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

public class CreateToDoOutput
{
    public CreateToDoOutput(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}