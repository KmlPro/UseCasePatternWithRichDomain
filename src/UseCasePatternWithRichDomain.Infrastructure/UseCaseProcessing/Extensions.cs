using Microsoft.Extensions.DependencyInjection;
using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Configuration;
using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Executor;
using UseCasePatternWithRichDomain.UseCases;

namespace UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing;

internal static class Extensions
{
    public static IServiceCollection AddUseCaseProcessing(this IServiceCollection services)
    {
        var assemblyWithUseCases = typeof(UseCaseMarker).Assembly;

        services.AddScoped<IUseCaseExecutor, UseCaseExecutor>();
        FluentValidationConfiguration.Register(services, assemblyWithUseCases);
        MediatrConfiguration.Register(services, assemblyWithUseCases);
        
        return services;
    }
}