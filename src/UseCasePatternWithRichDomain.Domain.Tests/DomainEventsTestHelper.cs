using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UseCasePatternWithRichDomain.BuildingBlocks;

namespace UseCasePatternWithRichDomain.Domain.Tests
{
    public static class DomainEventsTestHelper
    {
        public static List<IDomainEvent> GetAllDomainEvents(AggregateRoot aggregate)
        {
            var domainEvents = new List<IDomainEvent>();

            if (aggregate.DomainEvents != null)
            {
                domainEvents.AddRange(aggregate.DomainEvents);
            }

            var fields = aggregate.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                .Concat(aggregate.GetType().BaseType
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)).ToArray();

            foreach (var field in fields)
            {
                var isEntity = field.FieldType.IsAssignableFrom(typeof(AggregateRoot));

                if (isEntity)
                {
                    var entity = field.GetValue(aggregate) as AggregateRoot;
                    domainEvents.AddRange(GetAllDomainEvents(entity).ToList());
                }

                if (field.FieldType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                {
                    if (field.GetValue(aggregate) is IEnumerable enumerable)
                    {
                        foreach (var en in enumerable)
                        {
                            if (en is AggregateRoot entityItem)
                            {
                                domainEvents.AddRange(GetAllDomainEvents(entityItem));
                            }
                        }
                    }
                }
            }

            return domainEvents;
        }
    }
}
