using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Configuration;

internal static class FluentValidationConfiguration
{
    internal static void Register(IServiceCollection services, Assembly assemblyWithValidators)
    {
        services.AddValidatorsFromAssembly(assemblyWithValidators);
    }
}    