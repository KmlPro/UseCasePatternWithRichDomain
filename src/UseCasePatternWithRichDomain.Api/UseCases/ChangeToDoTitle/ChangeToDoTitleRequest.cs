namespace UseCasePatternWithRichDomain.Api.UseCases.ChangeToDoTitle;

public record ChangeToDoTitleRequest(Guid Id, string Title);