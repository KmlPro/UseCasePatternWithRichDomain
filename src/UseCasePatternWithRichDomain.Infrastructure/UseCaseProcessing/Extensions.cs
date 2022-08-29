using Microsoft.Extensions.DependencyInjection;
using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Configuration;
using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Executor;
using UseCasePatternWithRichDomain.UseCases;

namespace UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing;

internal static class Extensions
{
    public static IServiceCollection AddUseCaseProcessing(this IServiceCollection services)
    {
        var useCaseAssembly = typeof(UseCaseMarker).Assembly;
        var infrastructureAssembly = typeof(InfrastructureMarker).Assembly;

        services.AddScoped<IUseCaseExecutor, UseCaseExecutor>();
        FluentValidationConfiguration.Register(services, useCaseAssembly);
        MediatrConfiguration.Register(services, useCaseAssembly, infrastructureAssembly);

        return services;
    }
}