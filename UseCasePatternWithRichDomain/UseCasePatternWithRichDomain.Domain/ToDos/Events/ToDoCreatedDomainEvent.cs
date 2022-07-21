using UseCasePatternWithRichDomain.BuildingBlocks;

namespace UseCasePatternWithRichDomain.ToDos.Events;

public class ToDoCreatedDomainEvent : DomainEvent
{
    public string Title { get; }
    
    public ToDoCreatedDomainEvent(EntityId entityId, string title) : base(entityId.Value)
    {
        Title = title;
    }
}