using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo;

public interface IUseCase : IUseCase<CompleteToDoInput, IOutputPort>
{ }