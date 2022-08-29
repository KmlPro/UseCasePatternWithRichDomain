using Microsoft.Extensions.DependencyInjection;
using ToDoAsLessCodeAsPossible.BuildingBlocks.Infrastructure.Persistance.InMemory;
using UseCasePatternWithRichDomain.Infrastructure;
using UseCasePatternWithRichDomain.Infrastructure.Persistence;
using UseCasePatternWithRichDomain.Infrastructure.UseCases;

namespace UseCasePatternWithRichDomain.UseCases.Tests;

public class DependencyContainer
{
    private IServiceProvider _provider;
    private readonly IServiceCollection _services;
    
    public DependencyContainer()
    {
        _services = new ServiceCollection();
        _services.AddInfrastructure();
        _services.AddInMemoryPersistence<ToDoWriteDbContext>(new InMemoryDatabaseParameters(InMemoryDatabaseProvider.Sqlite));
    }

    public void BuildContainerAndSetupDatabase()
    {
        _provider = _services.BuildServiceProvider();
        
        DatabaseCreator.CreateDatabaseSchema(_provider);
    }

    public void RegisterMockType<TType>(object instance) where TType: class
    {
        _services.AddScoped<TType>(x => (TType)instance);
    }

    public TService GetService<TService>() where TService : notnull
    {
        return _provider.GetRequiredService<TService>();
    }

    public IUseCaseExecutor GetUseCaseExecutor()
    {
        return _provider.GetRequiredService<IUseCaseExecutor>();
    }
}