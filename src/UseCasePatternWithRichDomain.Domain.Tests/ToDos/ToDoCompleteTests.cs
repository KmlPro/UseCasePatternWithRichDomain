using NUnit.Framework;
using Shouldly;
using UseCasePatternWithRichDomain.ToDos;
using UseCasePatternWithRichDomain.ToDos.Events;
using UseCasePatternWithRichDomain.ToDos.Rules.CantCompleteAlreadyCompletedToDo;

namespace UseCasePatternWithRichDomain.Domain.Tests.ToDos;

public class ToDoCompleteTests : TestBase
{
    [Test]
    public void ToDoUncompleted_SuccessfullyCompleted()
    {
        //Arrange
        var toDo = ToDo.Create("MyToDo");

        //Act
        toDo.Complete();

        //Assert
        var completedDomainEvent = AssertPublishedDomainEvent<ToDoMarkedAsCompletedDomainEvent>(toDo);
        Assert.NotNull(completedDomainEvent);
    }

    [Test]
    public void ToDoCompleted_ThrowsException()
    {
        //Arrange
        var toDo = ToDo.Create("MyToDo");
        toDo.Complete();

        //Act & Assert
        AssertBrokenRule<CantCompleteAlreadyCompletedToDoRule>(() => { toDo.Complete(); });
    }
}