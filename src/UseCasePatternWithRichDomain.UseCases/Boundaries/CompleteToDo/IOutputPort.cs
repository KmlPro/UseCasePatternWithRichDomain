using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.OutputPort;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo;

public interface IOutputPort : IUseCaseOutput, IOutputPortBusinessError, IOutputPortStandard<CompleteToDoOutput>
{ }