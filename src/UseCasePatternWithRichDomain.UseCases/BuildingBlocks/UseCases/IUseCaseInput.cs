using MediatR;

namespace UseCasePatternWithRichDomain.UseCases.BuildingBlocks.UseCases
{
    public interface IUseCaseInput<out TUseCaseOutput> : IRequest<TUseCaseOutput> where TUseCaseOutput : IUseCaseOutput
    {
    }
}
