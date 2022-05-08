using Chat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Data.Repositories;

/// <summary>
/// Represents an implementation for a chat message repository.
/// </summary>
public interface IChatMessageRepository : IRepository<ChatMessageEntity>, IDisposable, IAsyncDisposable {}

/// <summary>
/// Represents an implementation of a chat message repository.
/// </summary>
public class ChatMessageRepository : IChatMessageRepository
{
    /// <summary>
    /// The chat message DB context.
    /// </summary>
    private readonly ChatDbContext _dbContext;

    /// <summary>
    /// Constructs a new instance of <see cref="ChatMessageRepository"/>.
    /// </summary>
    /// <param name="dbContext">The chat message DB context.</param>
    public ChatMessageRepository(ChatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc cref="IRepository{TEntity}.Get"/>
    public Task<IQueryable<ChatMessageEntity>> Get(int page = 0, int pageSize = 0, CancellationToken cancellationToken = default)
    {
        IQueryable<ChatMessageEntity> result;
        if (pageSize <= 0)      // return all results
            result = _dbContext.ChatMessages;
        else if (page <= 0)     // return first page results
            result = _dbContext.ChatMessages.Take(pageSize);
        else                    // return specific page results
            result = _dbContext.ChatMessages.Skip(page * pageSize).Take(pageSize);
        return Task.FromResult(result);
    }

    /// <inheritdoc cref="IRepository{TEntity}.Add(TEntity, CancellationToken)"/>
    public async Task Add(ChatMessageEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.ChatMessages.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc cref="IRepository{TEntity}.Add(IEnumerable{TEntity}, CancellationToken)"/>
    public async Task Add(IEnumerable<ChatMessageEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbContext.ChatMessages.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc cref="IRepository{TEntity}.Delete(TEntity, CancellationToken)"/>
    public Task Delete(ChatMessageEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Remove(entity);
        return Task.CompletedTask;
    }

    /// <inheritdoc cref="IRepository{TEntity}.Delete(IEnumerable{TEntity}, CancellationToken)"/>
    public Task Delete(IEnumerable<ChatMessageEntity> entities, CancellationToken cancellationToken = default)
    {
        _dbContext.RemoveRange(entities);
        return Task.CompletedTask;
    }

    /// <inheritdoc cref="IRepository{TEntity}.Update"/>
    public Task Update(ChatMessageEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    /// <inheritdoc cref="IRepository{TEntity}.Save"/>
    public Task<int> Save(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc cref="IDisposable.Dispose"/>
    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc cref="IAsyncDisposable.DisposeAsync"/>
    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync().ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }
}
