using UseCasePatternWithRichDomain.BuildingBlocks;

namespace UseCasePatternWithRichDomain.ToDos.Events;

public class ToDoTitleChangedDomainEvent: DomainEvent
{
    public string Title { get; }
    
    public ToDoTitleChangedDomainEvent(EntityId entityId, string title) : base(entityId.Value)
    {
        Title = title;
    }
}