using UseCasePatternWithRichDomain.BuildingBlocks;
using UseCasePatternWithRichDomain.UseCases.Boundaries.MarkToDoAsUncompleted;
using UseCasePatternWithRichDomain.UseCases.Services;
using IOutputPort = UseCasePatternWithRichDomain.UseCases.Boundaries.MarkToDoAsUncompleted.IOutputPort;
using IUseCase = UseCasePatternWithRichDomain.UseCases.Boundaries.MarkToDoAsUncompleted.IUseCase;

namespace UseCasePatternWithRichDomain.UseCases.UseCases.MarkToDoAsUncompleted;

public class MarkToDoAsUncompletedUseCase : IUseCase
{
    private readonly IOutputPort _outputPort;
    private readonly IToDoWriteRepository _toDoWriteRepository;

    public MarkToDoAsUncompletedUseCase(IOutputPort outputPort, IToDoWriteRepository toDoWriteRepository)
    {
        _outputPort = outputPort;
        _toDoWriteRepository = toDoWriteRepository;
    }

    public async Task<IOutputPort> Handle(MarkToDoAsUncompletedInput input, CancellationToken cancellationToken)
    {
        try
        {
            var entityId = new EntityId(input.Id);
            var toDo = await _toDoWriteRepository.GetAsync(entityId, cancellationToken);
            toDo.MarkAsUncompleted();
            
            _outputPort.WriteStandard(new MarkToDoAsUncompletedOutput(toDo.Id.Value));
        }
        catch (BusinessRuleValidationException ex)
        {
            _outputPort.WriteBusinessRuleError(ex.ToString());
        }

        return _outputPort;
    }
}