using Chat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Data;

/// <summary>
/// Represents a DB context for chat messages.
/// </summary>
public class ChatDbContext : DbContext
{
    /// <summary>
    /// Gets the DB set for chat messages.
    /// </summary>
    public DbSet<ChatMessageEntity> ChatMessages => Set<ChatMessageEntity>();
    
    /// <summary>
    /// Constructs a new instance of <see cref="ChatDbContext"/>.
    /// </summary>
    /// <param name="opt">DB context options.</param>
    public ChatDbContext(DbContextOptions<ChatDbContext> opt) : base(opt)
    {
        DisableChangeTracking();
    }
    
    /// <summary>
    /// Disables auto detect changes in EF.
    /// </summary>
    private void DisableChangeTracking()
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }
}
