using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.ValidationErrors;

namespace UseCasePatternWithRichDomain.Api.UseCases.CreateToDo;

public class CreateToDoPresenter : IOutputPort
{
    public IResult ViewModel { get; private set; } = Results.NoContent();

    public void WriteInvalidInput(List<InvalidUseCaseInputValidationError> errors)
    {
        ViewModel = Results.BadRequest(errors);
    }

    public void WriteBusinessRuleError(string message)
    {
        ViewModel = Results.UnprocessableEntity(message);
    }

    public void Standard(CreateToDoOutput output)
    {
        ViewModel = Results.Created(new Uri($"/todo/{output.Id}"), null);
    }
}