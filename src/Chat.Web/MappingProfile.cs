using AutoMapper;
using Chat.Data.Entities;
using Chat.Data.Models;

namespace Chat.Web;

/// <summary>
/// Represents an auto mapper profile.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Constructs a new instance of <see cref="MappingProfile"/>.
    /// </summary>
    public MappingProfile()
    {
        // product
        CreateMap<ChatMessageEntity, ChatMessage>();
        CreateMap<ChatMessage, ChatMessageEntity>();
    }
}
