using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UseCasePatternWithRichDomain.Infrastructure.Persistence.StronglyTypedIdConfiguration;

namespace UseCasePatternWithRichDomain.Infrastructure.Persistence.InMemory.DatabaseConfiguration;

internal class InMemoryEfDatabaseConfigurationFactory
{
    public Action<DbContextOptionsBuilder> Create()
    {
        return builder =>
        {
            builder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
            builder.UseInMemoryDatabase("IncidentReport");
        };
    }
}