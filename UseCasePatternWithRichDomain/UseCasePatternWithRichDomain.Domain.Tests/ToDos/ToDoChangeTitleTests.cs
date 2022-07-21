using NUnit.Framework;
using UseCasePatternWithRichDomain.ToDos;
using UseCasePatternWithRichDomain.ToDos.Events;

namespace UseCasePatternWithRichDomain.Domain.Tests.ToDos;

public class ToDoChangeTitleTests : TestBase
{
    [Test]
    public void HappyPath_ToDoTitleChangedDomainEventPublished()
    {
        //Arrange
        var toDo = ToDo.Create("MyToDo");

        //Act
        toDo.ChangeTitle("My Fancy title");

        //Assert
        var titleChangedDomainEvent = AssertPublishedDomainEvent<ToDoTitleChangedDomainEvent>(toDo);
        Assert.NotNull(titleChangedDomainEvent);
    }

    [Test]
    public void TitleIsNull_ThrowsArgumentNullException()
    {
        //Arrange
        var toDo = ToDo.Create("MyToDo");

        //Act & Assert
        AssertException<ArgumentNullException>(() => { toDo.ChangeTitle(null); });
    }

    [Test]
    public void TitleIsNull_ThrowsExceptionCompleted()
    {
        //Arrange
        var toDo = ToDo.Create("MyToDo");

        //Act & Asser
        AssertException<ArgumentException>(() => { toDo.ChangeTitle(""); });
    }
}