using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoAsLessCodeAsPossible.BuildingBlocks.Infrastructure.Persistance.InMemory;
using UseCasePatternWithRichDomain.Infrastructure.Persistence.InMemory.DatabaseConfiguration;
using UseCasePatternWithRichDomain.Infrastructure.Persistence.Repositories;
using UseCasePatternWithRichDomain.Infrastructure.Persistence.Transactions;
using UseCasePatternWithRichDomain.UseCases.Services;

namespace UseCasePatternWithRichDomain.Infrastructure.Persistence;

internal static class Extensions
{
    public static IServiceCollection AddInMemoryPersistence<TDbContext>(this IServiceCollection services,
        InMemoryDatabaseParameters parameters) where TDbContext : DbContext
    {
        services.AddScoped<IToDoWriteRepository, ToDoWriteRepository>();
        
        var optionsBuilder = parameters.DatabaseProvider switch
        {
            InMemoryDatabaseProvider.Sqlite => new InMemorySqliteConfigurationFactory().Create(),
            InMemoryDatabaseProvider.EfCore => new InMemoryEfDatabaseConfigurationFactory().Create(),
            _ => throw new NotSupportedException(
                $"Database Provider {parameters.DatabaseProvider.ToString()} is not supported")
        };

        services.AddDbContext<TDbContext>(optionsBuilder);
        services.AddScoped<IUnitOfWork>(services =>
            new UnitOfWork(services.GetRequiredService<TDbContext>()));
        
        return services;
    }
}