using NUnit.Framework;
using Shouldly;
using UseCasePatternWithRichDomain.BuildingBlocks;
using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Executor;
using UseCasePatternWithRichDomain.UseCases.Boundaries.CreateToDo;
using UseCasePatternWithRichDomain.UseCases.Services;

namespace UseCasePatternWithRichDomain.UseCases.Tests.UseCases.CreateToDo;

public class CreateToDoUseCaseTests
{
    private readonly IUseCaseExecutor _useCaseExecutor;
    private readonly DependencyContainer _dependencyContainer;
    private readonly IToDoWriteRepository _toDoWriteRepository;
    
    public CreateToDoUseCaseTests()
    {
        _dependencyContainer = new DependencyContainer();
        _dependencyContainer.RegisterMockType<IOutputPort>(new CreateToDoUseCaseOutputPort());
        _dependencyContainer.BuildContainerAndSetupDatabase();
        
        _useCaseExecutor = _dependencyContainer.GetUseCaseExecutor();
        _toDoWriteRepository = _dependencyContainer.GetService<IToDoWriteRepository>();
    }
    
    [Test]
    public async Task CorrectUseCaseParameters_ToDoCreated()
    {
        //Arrange
        var command = new CreateToDoInput("Fancy to Do");
        
        //Act
        var result = (CreateToDoUseCaseOutputPort)await _useCaseExecutor.Execute(command, CancellationToken.None);
        
        //Assert
        result.InvokedOutputMethod.ShouldBe(OutputPortInvokedMethod.Standard);
        
        var id = new EntityId(new Guid(result.Id));
        var toDo = await _toDoWriteRepository.GetAsync(id, CancellationToken.None);
        toDo.ShouldNotBeNull();
    }
}