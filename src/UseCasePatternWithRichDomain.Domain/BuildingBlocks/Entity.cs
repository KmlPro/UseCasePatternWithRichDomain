using System;
using System.Collections.Generic;

namespace UseCasePatternWithRichDomain.BuildingBlocks;

public abstract class AggregateRoot : WithCheckRule
{
    private List<DomainEvent> _domainEvents;
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents ??= new List<DomainEvent>();
        _domainEvents.Add(domainEvent);
    }

    protected void CopyDomainEvents(AggregateRoot aggregateRoot)
    {
        if (aggregateRoot == null)
        {
            throw new ArgumentNullException(nameof(aggregateRoot));
        }
        _domainEvents ??= new List<DomainEvent>();
        _domainEvents.AddRange(aggregateRoot.DomainEvents);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}