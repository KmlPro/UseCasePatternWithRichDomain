using EntityFramework.Exceptions.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UseCasePatternWithRichDomain.Infrastructure.Persistence.StronglyTypedIdConfiguration;

namespace UseCasePatternWithRichDomain.Infrastructure.Persistence.Databases.Sqlite;

public class SqliteConfigurationFactory
{
    public Action<DbContextOptionsBuilder> Create(SqliteDatabaseParameters parameters)
    {
        return builder =>
        {
            builder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
            builder.UseSqlite(parameters.ConnectionString);
            builder.UseExceptionProcessor();
        };
    }
}