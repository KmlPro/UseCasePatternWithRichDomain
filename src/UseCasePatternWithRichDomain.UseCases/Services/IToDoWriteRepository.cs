using UseCasePatternWithRichDomain.BuildingBlocks;
using UseCasePatternWithRichDomain.ToDos;

namespace UseCasePatternWithRichDomain.UseCases.Services;

public interface IToDoWriteRepository
{
    public Task<ToDo> GetAsync(EntityId id, CancellationToken token);
    public Task AddAsync(ToDo toDoEntity, CancellationToken token);
    public Task<bool> ExistsAsync(string title, CancellationToken token);
    public Task<bool> ExistsAsync(EntityId id, CancellationToken token);
}