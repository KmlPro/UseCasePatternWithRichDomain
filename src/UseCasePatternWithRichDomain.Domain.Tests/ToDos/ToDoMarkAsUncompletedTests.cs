using NUnit.Framework;
using Shouldly;
using UseCasePatternWithRichDomain.ToDos;
using UseCasePatternWithRichDomain.ToDos.Events;
using UseCasePatternWithRichDomain.ToDos.Rules.CantMarkAsUncompletedAlreadyUncompleted;

namespace UseCasePatternWithRichDomain.Domain.Tests.ToDos;

public class ToDoMarkAsUncompletedTests : TestBase
{
    [Test]
    public void ToDoCompleted_SuccessfullyCompleted()
    {
        //Arrange
        var toDo = ToDo.Create("MyToDo");
        toDo.Complete();

        //Act
        toDo.MarkAsUncompleted();

        //Assert
        var uncompletedDomainEvent = AssertPublishedDomainEvent<ToDoMarkedAsUncompletedDomainEvent>(toDo);
        Assert.NotNull(uncompletedDomainEvent);
    }

    [Test]
    public void ToDoCompleted_ThrowsException()
    {
        //Arrange
        var toDo = ToDo.Create("MyToDo");

        //Act & Asser
        AssertBrokenRule<CantMarkAsUncompletedAlreadyUncompletedRule>(() => { toDo.MarkAsUncompleted(); });
    }
}