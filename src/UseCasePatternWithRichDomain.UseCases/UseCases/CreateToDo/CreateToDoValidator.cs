using FluentValidation;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

namespace UseCasePatternWithRichDomain.UseCases.UseCases.CreateToDo;

public class CreateToDoValidator : AbstractValidator<CreateToDoInput>
{
    public CreateToDoValidator()
    {
        RuleFor(x => x.Title).NotNull().MinimumLength(5);
    }
}