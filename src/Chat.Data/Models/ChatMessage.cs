using System.ComponentModel.DataAnnotations;

namespace Chat.Data.Models;

/// <summary>
/// Represents a chat message.
/// </summary>
public class ChatMessage
{
    /// <summary>
    /// Gets or sets the message ID.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the message sender username.
    /// </summary>
    [StringLength(32, MinimumLength = 3)]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the message content.
    /// </summary>
    [StringLength(5000, MinimumLength = 1)]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date the message is sent.
    /// </summary>
    public DateTime DateSent { get; set; } = DateTime.Now;

    /// <summary>
    /// Resets this object, generating a new ID and updating the time to now.
    /// </summary>
    public void Reset()
    {
        Id = Guid.NewGuid();
        DateSent = DateTime.Now;
    }

    /// <inheritdoc cref="object.ToString"/>
    public override string ToString()
    {
        return $"{DateSent.ToString("dd/MM")} {Username}: {Message}";
    }
}
