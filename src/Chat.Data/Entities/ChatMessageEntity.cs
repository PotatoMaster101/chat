using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Data.Entities;

/// <summary>
/// Represents the chat message entity/DTO.
/// </summary>
[Table("ChatMessage")]
public class ChatMessageEntity
{
    /// <summary>
    /// Gets or sets the message ID.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the message sender username.
    /// </summary>
    [Required]
    [MaxLength(32)]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the message content.
    /// </summary>
    [Required]
    [MaxLength(5000)]
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the date the message is sent.
    /// </summary>
    [Required]
    public DateTime DateSent { get; set; }
}
