using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle;

public interface IUseCase : IUseCase<ChangeToDoTitleInput, IOutputPort>
{ }