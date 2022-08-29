using System.Threading;
using System.Threading.Tasks;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.Infrastructure.UseCases;

public interface IUseCaseExecutor
{
    public Task<TUseCaseOutput> Execute<TUseCaseOutput>(IUseCaseInput<TUseCaseOutput> useCase, CancellationToken token)
        where TUseCaseOutput : IUseCaseOutput;
}