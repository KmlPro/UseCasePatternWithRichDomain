using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.OutputPort;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle;

public interface IOutputPort : IUseCaseOutput, IOutputPortInvalidInput, IOutputPortStandard<ChangeToDoTitleOutput>
{ }