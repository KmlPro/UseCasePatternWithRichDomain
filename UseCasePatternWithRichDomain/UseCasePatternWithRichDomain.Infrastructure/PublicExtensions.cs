using Microsoft.Extensions.DependencyInjection;
using UseCasePatternWithRichDomain.UseCases;

namespace UseCasePatternWithRichDomain.Infrastructure;

public static class PublicExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var useCasesAssembly = typeof(UseCaseMarker).Assembly;
        var infrastructureAssembly = typeof(PublicExtensions).Assembly;
        
        return services;
    }
}