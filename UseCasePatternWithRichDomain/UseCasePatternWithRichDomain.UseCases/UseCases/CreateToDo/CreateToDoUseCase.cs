using FluentValidation;
using UseCasePatternWithRichDomain.BuildingBlocks;
using UseCasePatternWithRichDomain.ToDos;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.ValidationErrors;
using UseCasePatternWithRichDomain.UseCases.Services;

namespace UseCasePatternWithRichDomain.UseCases.UseCases.CreateToDo;

public class CreateToDoUseCase : IUseCase
{
    private readonly IOutputPort _outputPort;
    private readonly IValidator<CreateToDoInput> _validator;
    private readonly IToDoWriteRepository _toDoWriteRepository;

    public CreateToDoUseCase(IOutputPort outputPort, IValidator<CreateToDoInput> validator, IToDoWriteRepository toDoWriteRepository)
    {
        _outputPort = outputPort;
        _validator = validator;
        _toDoWriteRepository = toDoWriteRepository;
    }

    public async Task<IOutputPort> Handle(CreateToDoInput input, CancellationToken cancellationToken)
    {
        try
        {
            await _validator.ValidateAndThrowAsync(input, cancellationToken);
            var toDo = ToDo.Create(input.Title);
            await _toDoWriteRepository.AddAsync(toDo, cancellationToken);
        }
        catch (BusinessRuleValidationException ex)
        {
            _outputPort.WriteBusinessRuleError(ex.ToString());
        }
        catch (ValidationException ex)
        {
            _outputPort.WriteInvalidInput(ex.MapToInvaliInputErrors());
        }

        return _outputPort;
    }
}