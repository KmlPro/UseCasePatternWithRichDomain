using UseCasePatternWithRichDomain.BuildingBlocks;

namespace UseCasePatternWithRichDomain.ToDos.Events;

public class ToDoMarkedAsCompletedDomainEvent : DomainEvent
{
    public ToDoMarkedAsCompletedDomainEvent(EntityId entityId) : base(entityId.Value)
    {
    }
}