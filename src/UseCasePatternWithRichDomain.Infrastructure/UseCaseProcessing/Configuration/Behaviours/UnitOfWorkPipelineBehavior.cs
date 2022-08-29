using MediatR;
using UseCasePatternWithRichDomain.Infrastructure.Persistence.Transactions;

namespace UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Configuration.Behaviours;

public class UnitOfWorkPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkPipelineBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        await using var transaction = _unitOfWork.BeginTransaction();
        var result = await next().ConfigureAwait(false);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return result;
    }
}