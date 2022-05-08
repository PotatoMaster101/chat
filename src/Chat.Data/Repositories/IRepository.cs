namespace Chat.Data.Repositories;

/// <summary>
/// Represents an implementation of repository pattern.
/// </summary>
/// <typeparam name="TEntity">The entity/DTO type.</typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Gets the list of entities.
    /// </summary>
    /// <param name="page">The specific page of entities to get.</param>
    /// <param name="pageSize">The count of entities on each page. Set to 0 to retrieve all entities at once.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The list of entities.</returns>
    Task<IQueryable<TEntity>> Get(int page = 0, int pageSize = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    Task Add(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a list of entities.
    /// </summary>
    /// <param name="entities">The entities to add.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    Task Add(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    Task Delete(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a list of entities.
    /// </summary>
    /// <param name="entities">The entities to delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    Task Delete(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    Task Update(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Saves changes made so far.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The number of entities saved.</returns>
    Task<int> Save(CancellationToken cancellationToken = default);
}
