using System;

namespace UseCasePatternWithRichDomain.BuildingBlocks;

public class EntityId
{
    public Guid Value { get; }
    
    public EntityId(Guid guid)
    {
        Value = guid;
    }

    public static EntityId Create()
    {
        return new EntityId(Guid.NewGuid());
    }
}