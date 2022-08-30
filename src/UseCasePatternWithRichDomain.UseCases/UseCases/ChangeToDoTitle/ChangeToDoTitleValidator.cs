using FluentValidation;
using UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle;

namespace UseCasePatternWithRichDomain.UseCases.UseCases.ChangeToDoTitle;

public class ChangeToDoTitleValidator : AbstractValidator<ChangeToDoTitleInput>
{
    public ChangeToDoTitleValidator()
    {
        RuleFor(x => x.Title).NotNull().MinimumLength(5);
    }
}