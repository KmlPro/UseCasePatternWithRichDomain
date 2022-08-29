using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UseCasePatternWithRichDomain.ToDos;

namespace UseCasePatternWithRichDomain.Infrastructure.Persistence.TableConfiguration;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property("_title").HasMaxLength(100).IsRequired();
        builder.Property("_isCompleted").IsRequired();

        builder.Ignore(o => o.DomainEvents);
    }
}