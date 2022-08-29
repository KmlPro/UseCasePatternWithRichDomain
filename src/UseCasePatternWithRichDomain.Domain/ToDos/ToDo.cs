using EnsureThat;
using UseCasePatternWithRichDomain.BuildingBlocks;
using UseCasePatternWithRichDomain.ToDos.Events;
using UseCasePatternWithRichDomain.ToDos.Rules.CantCompleteAlreadyCompletedToDo;
using UseCasePatternWithRichDomain.ToDos.Rules.CantMarkAsUncompletedAlreadyUncompleted;

namespace UseCasePatternWithRichDomain.ToDos;

public class ToDo : AggregateRoot
{
    public EntityId Id { get; }
    private string _title;
    private bool _isCompleted;

    private ToDo(EntityId id, string title)
    {
        Ensure.That(title, nameof(title)).IsNotNullOrWhiteSpace();

        Id = id;
        _title = title;
        _isCompleted = false;
    }

    public static ToDo Create(string title)
    {
        var id = EntityId.Create();
        var toDo = new ToDo(id, title);
        
        toDo.AddDomainEvent(new ToDoCreatedDomainEvent(id, title));
        
        return toDo;
    }

    public void Complete()
    {
        CheckRule(new CantCompleteAlreadyCompletedToDoRule(_isCompleted));
        _isCompleted = true;
        AddDomainEvent(new ToDoMarkedAsCompletedDomainEvent(Id));
    }

    public void MarkAsUnCompleted()
    {
        CheckRule(new CantMarkAsUncompletedAlreadyUncompletedRule(_isCompleted));
        _isCompleted = false;
        AddDomainEvent(new ToDoMarkedAsUncompletedDomainEvent(Id));
    }

    public void ChangeTitle(string title)
    {
        Ensure.That(title, nameof(title)).IsNotNullOrWhiteSpace();
        _title = title;
        AddDomainEvent(new ToDoTitleChangedDomainEvent(Id,_title));
    }
}