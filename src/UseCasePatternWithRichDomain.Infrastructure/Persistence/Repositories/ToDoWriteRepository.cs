using Microsoft.EntityFrameworkCore;
using UseCasePatternWithRichDomain.BuildingBlocks;
using UseCasePatternWithRichDomain.ToDos;
using UseCasePatternWithRichDomain.UseCases.Services;

namespace UseCasePatternWithRichDomain.Infrastructure.Persistence.Repositories;

internal class ToDoWriteRepository : IToDoWriteRepository
{
    private readonly ToDoWriteDbContext _writeDbContext;

    public ToDoWriteRepository(ToDoWriteDbContext writeDbContext)
    {
        _writeDbContext = writeDbContext;
    }

    public async Task<ToDo> GetAsync(EntityId id, CancellationToken token)
    {
        var toDo = await _writeDbContext.ToDo.FindAsync(id);
        //TO do add dedicated exception
        return toDo!;
    }

    public async Task AddAsync(ToDo toDoEntity, CancellationToken token)
    {
        await _writeDbContext.ToDo.AddAsync(toDoEntity, token);
    }

    public async Task<bool> ExistsAsync(string title, CancellationToken token)
    {
        var exists = await _writeDbContext.ToDo.AnyAsync(a => EF.Property<string>(a, "_title") == title, token);
        return exists;
    }

    //kbytner 17.07.2022 - I don't use Any() there due to FindAsync will store ToDo instance in memory 
    public async Task<bool> ExistsAsync(EntityId id, CancellationToken token)
    {
        var toDo = await _writeDbContext.ToDo.FindAsync(id, token);
        return toDo != null;
    }
}