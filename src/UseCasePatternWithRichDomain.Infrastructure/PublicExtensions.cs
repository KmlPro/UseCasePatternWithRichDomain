using Microsoft.Extensions.DependencyInjection;
using UseCasePatternWithRichDomain.Infrastructure.Persistence;
using UseCasePatternWithRichDomain.Infrastructure.Persistence.InMemory;
using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing;

namespace UseCasePatternWithRichDomain.Infrastructure;

public static class PublicExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddInMemoryPersistence<ToDoWriteDbContext>(
            new InMemoryDatabaseParameters(InMemoryDatabaseProvider.Sqlite));

        services.AddUseCaseProcessing();
        
        return services;
    }
}