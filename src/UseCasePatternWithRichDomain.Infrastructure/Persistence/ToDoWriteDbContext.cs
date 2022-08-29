using Microsoft.EntityFrameworkCore;

namespace UseCasePatternWithRichDomain.Infrastructure.Persistence;

internal class ToDoWriteDbContext : DbContext
{
    public ToDoWriteDbContext(DbContextOptions options) : base(options){ }
 
    //public DbSet<ToDo> ToDo { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     //   modelBuilder.ApplyConfiguration(new ToDoConfiguration());
    }
}