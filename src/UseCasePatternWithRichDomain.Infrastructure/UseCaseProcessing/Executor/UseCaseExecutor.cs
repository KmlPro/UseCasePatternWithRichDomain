using MediatR;
using UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases;

namespace UseCasePatternWithRichDomain.Infrastructure.UseCaseProcessing.Executor;

public class UseCaseExecutor : IUseCaseExecutor
{
    private readonly IMediator _mediator;

    public UseCaseExecutor(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<TUseCaseOutput> Execute<TUseCaseOutput>(IUseCaseInput<TUseCaseOutput> useCase, CancellationToken token) where TUseCaseOutput : IUseCaseOutput
    {
        return await _mediator.Send(useCase, token);
    }
}