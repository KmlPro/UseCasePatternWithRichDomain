using MediatR;

namespace UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases
{
    /// <typeparam name="TUseCaseInput">Any Input Message.</typeparam>
    public interface IUseCase<in TUseCaseInput, TUseCaseOutput> : IRequestHandler<TUseCaseInput, TUseCaseOutput>
        where TUseCaseInput : IUseCaseInput<TUseCaseOutput>
        where TUseCaseOutput : IUseCaseOutput
    {
    }
}
