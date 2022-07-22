using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

public interface IUseCase : IUseCase<CreateToDoInput, IOutputPort>
{ }