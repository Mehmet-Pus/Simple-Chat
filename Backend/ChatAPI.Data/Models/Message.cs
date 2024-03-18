using ChatAPI.Core;
using ChatAPI.Core.Domain;

namespace ChatAPI.Data.Models;

public class Message : BaseEntity
{
    public Message()
    {
        Text = default!;
        SenderId = default!;
        ChatRoomId = default!;
        ChatRoom = default!;
    }
    
    public string Text { get; set; }
    public int SenderId { get; set; }
    public int ChatRoomId { get; set; }

    public ChatRoom ChatRoom { get; set; }
}