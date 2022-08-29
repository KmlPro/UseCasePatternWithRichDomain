using Microsoft.EntityFrameworkCore.Storage;

namespace UseCasePatternWithRichDomain.Infrastructure.Persistence.Transactions;

public interface IUnitOfWork
{
    public IDbContextTransaction BeginTransaction();
    public Task SaveChangesAsync(CancellationToken token);
}