using System.Collections.Generic;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.ValidationErrors;

namespace UseCasePatternWithRichDomain.UseCases.BuildingBlocks.OutputPort
{
    public interface IOutputPortInvalidInput
    {
        /// <summary>
        ///     Informs the resource was not found.
        /// </summary>
        void WriteInvalidInput(List<InvalidUseCaseInputValidationError> errors);
    }
}
