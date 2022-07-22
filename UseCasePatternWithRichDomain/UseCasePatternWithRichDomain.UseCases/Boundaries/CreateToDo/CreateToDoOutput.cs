namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

public class CreateToDoOutput
{
    public CreateToDoOutput(string id)
    {
        Id = id;
    }

    public string Id { get; }
}