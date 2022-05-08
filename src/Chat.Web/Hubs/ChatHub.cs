using Chat.Data.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Web.Hubs;

/// <summary>
/// Represents a SignalR hub for sending/receiving messages.
/// </summary>
public class ChatHub : Hub
{
    /// <summary>
    /// Sends a message to all of the clients connected.
    /// </summary>
    /// <param name="message">The message to send.</param>
    public Task SendMessage(ChatMessage message)
    {
        return Clients.All.SendAsync("ReceiveMessage", message);
    }
}
