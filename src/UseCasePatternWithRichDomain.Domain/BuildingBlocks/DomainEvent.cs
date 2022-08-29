namespace UseCasePatternWithRichDomain.BuildingBlocks
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent(Guid entityId)
        {
            OccurredOn = SystemClock.Now;
            EntityId = entityId;
        }

        public DateTime OccurredOn { get; }
        public string Type => GetType().Name;
        public Guid EntityId { get; }
    }
}
