using UseCasePatternWithRichDomain.BuildingBlocks;
using UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle;
using UseCasePatternWithRichDomain.UseCases.Services;
using IOutputPort = UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle.IOutputPort;
using IUseCase = UseCasePatternWithRichDomain.UseCases.Boundaries.ChangeToDoTitle.IUseCase;
using FluentValidation;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.ValidationErrors;

namespace UseCasePatternWithRichDomain.UseCases.UseCases.ChangeToDoTitle;

public class ChangeToDoTitleUseCase : IUseCase
{
    private readonly IOutputPort _outputPort;
    private readonly IToDoWriteRepository _toDoWriteRepository;
    private readonly IValidator<ChangeToDoTitleInput> _validator;

    public ChangeToDoTitleUseCase(IOutputPort outputPort, IToDoWriteRepository toDoWriteRepository, IValidator<ChangeToDoTitleInput> validator)
    {
        _outputPort = outputPort;
        _toDoWriteRepository = toDoWriteRepository;
        _validator = validator;
    }

    public async Task<IOutputPort> Handle(ChangeToDoTitleInput input, CancellationToken cancellationToken)
    {
        try
        {
            await _validator.ValidateAndThrowAsync(input, cancellationToken);

            var entityId = new EntityId(input.Id);
            var toDo = await _toDoWriteRepository.GetAsync(entityId, cancellationToken);
            toDo.ChangeTitle(input.Title);
            
            _outputPort.WriteStandard(new ChangeToDoTitleOutput(toDo.Id.Value));
        }
        catch (ValidationException ex)
        {
            _outputPort.WriteInvalidInput(ex.MapToInvaliInputErrors());
        }

        return _outputPort;
    }
}