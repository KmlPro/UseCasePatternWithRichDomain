using System;

namespace UseCasePatternWithRichDomain.BuildingBlocks
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
        string Type { get; }
        public Guid EntityId { get; }
    }
}
