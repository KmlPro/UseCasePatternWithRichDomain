using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.MarkToDoAsUncompleted;

public interface IUseCase : IUseCase<MarkToDoAsUncompletedInput, IOutputPort>
{ }