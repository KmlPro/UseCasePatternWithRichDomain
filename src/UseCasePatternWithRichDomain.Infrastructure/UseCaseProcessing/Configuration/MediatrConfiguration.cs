using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Configuration.Behaviours;

namespace UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Configuration;

internal static class MediatrConfiguration
{
    internal static void Register(IServiceCollection services, Assembly useCaseAssembly, Assembly infrastructureAssembly)
    {
        services.AddMediatR(useCaseAssembly,infrastructureAssembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));
    }
}