using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UseCasePatternWithRichDomain.BuildingBlocks;

namespace UseCasePatternWithRichDomain.Domain.Tests;

public class TestBase
{
    public static T AssertPublishedDomainEvent<T>(AggregateRoot aggregate) where T : DomainEvent
    {
        var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();

        if (domainEvent == null)
        {
            throw new Exception($"{typeof(T).Name} event not published");
        }

        return domainEvent;
    }

    public static List<T> AssertPublishedDomainEvents<T>(AggregateRoot aggregate) where T : DomainEvent
    {
        var domainEvents = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().ToList();

        if (!domainEvents.Any())
        {
            throw new Exception($"{typeof(T).Name} event not published");
        }

        return domainEvents;
    }

    public static void AssertBrokenRule<TRule>(TestDelegate testDelegate) where TRule : class, IBusinessRule
    {
        var message = $"Expected {typeof(TRule).Name} broken rule";
        var businessRuleValidationException = Assert.Catch<BusinessRuleValidationException>(testDelegate, message);
        if (businessRuleValidationException != null)
        {
            Assert.That(businessRuleValidationException.BrokenRule, Is.TypeOf<TRule>(), message);
        }
    }

    public static void AssertException<TException>(TestDelegate testDelegate) where TException : Exception
    {
        var message = $"Expected {nameof(TException)} exception";
        var exception = Assert.Catch<Exception>(testDelegate, message);
        if (exception != null)
        {
            Assert.That(exception, Is.TypeOf<TException>(), message);
        }
    }
}