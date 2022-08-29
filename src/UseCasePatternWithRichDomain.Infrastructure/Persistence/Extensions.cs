using Microsoft.Extensions.DependencyInjection;
using UseCasePatternWithRichDomain.Infrastructure.Persistence.Repositories;
using UseCasePatternWithRichDomain.UseCases.Services;

namespace UseCasePatternWithRichDomain.Infrastructure.Persistence;

internal static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IToDoWriteRepository, ToDoWriteRepository>();
        
        //todo add in memory db
        return services;
    }
}