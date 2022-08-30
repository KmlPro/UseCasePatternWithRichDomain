using UseCasePatternWithRichDomain.BuildingBlocks;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo;
using UseCasePatternWithRichDomain.UseCases.Services;
using IOutputPort = UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo.IOutputPort;
using IUseCase = UseCasePatternWithRichDomain.UseCases.Boundaries.CompleteToDo.IUseCase;

namespace UseCasePatternWithRichDomain.UseCases.UseCases.CompleteToDo;

public class CompleteToDoUseCase : IUseCase
{
    private readonly IOutputPort _outputPort;
    private readonly IToDoWriteRepository _toDoWriteRepository;

    public CompleteToDoUseCase(IOutputPort outputPort, IToDoWriteRepository toDoWriteRepository)
    {
        _outputPort = outputPort;
        _toDoWriteRepository = toDoWriteRepository;
    }

    public async Task<IOutputPort> Handle(CompleteToDoInput input, CancellationToken cancellationToken)
    {
        try
        {
            var entityId = new EntityId(input.Id);
            var toDo = await _toDoWriteRepository.GetAsync(entityId, cancellationToken);
            toDo.Complete();
            
            _outputPort.WriteStandard(new CompleteToDoOutput(toDo.Id.Value));
        }
        catch (BusinessRuleValidationException ex)
        {
            _outputPort.WriteBusinessRuleError(ex.ToString());
        }

        return _outputPort;
    }
}