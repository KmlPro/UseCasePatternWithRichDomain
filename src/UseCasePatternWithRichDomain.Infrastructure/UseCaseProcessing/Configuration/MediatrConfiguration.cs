using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Configuration;

internal static class MediatrConfiguration
{
    internal static void Register(IServiceCollection services, Assembly assemblyWithMediatRComponentsImplementation)
    {
        services.AddMediatR(assemblyWithMediatRComponentsImplementation);
    }
}