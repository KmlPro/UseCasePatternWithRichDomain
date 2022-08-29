using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Executor;

public interface IUseCaseExecutor
{
    public Task<TUseCaseOutput> Execute<TUseCaseOutput>(IUseCaseInput<TUseCaseOutput> useCase, CancellationToken token)
        where TUseCaseOutput : IUseCaseOutput;
}