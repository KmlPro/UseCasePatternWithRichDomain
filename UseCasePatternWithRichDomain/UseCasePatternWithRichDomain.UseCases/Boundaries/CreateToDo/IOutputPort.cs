using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.OutputPort;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;

public interface IOutputPort : IUseCaseOutput, IOutputPortInvalidInput, IOutputPortBusinessError, IOutputPortStandard<CreateToDoOutput>
{ }