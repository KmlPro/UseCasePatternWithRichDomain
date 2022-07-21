using UseCasePatternWithRichDomain.BuildingBlocks;

namespace UseCasePatternWithRichDomain.ToDos.Events;

public class ToDoMarkedAsUncompletedDomainEvent: DomainEvent
{
    public ToDoMarkedAsUncompletedDomainEvent(EntityId entityId) : base(entityId.Value)
    {
    }
}