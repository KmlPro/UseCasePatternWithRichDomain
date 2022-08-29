using System.Collections.Generic;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.ValidationErrors;

namespace UseCasePatternWithRichDomain.UseCases.BuildingBlocks.OutputPort
{
    public interface IOutputPortInvalidInput
    {
        /// <summary>
        ///     Informs that use case input was incorrect.
        /// </summary>
        void WriteInvalidInput(List<InvalidUseCaseInputValidationError> errors);
    }
}
