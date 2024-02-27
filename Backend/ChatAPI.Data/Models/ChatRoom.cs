using ChatAPI.Core;

namespace ChatAPI.Data.Models;

public class ChatRoom : BaseEntity
{
    public string Name { get; set; }
    public bool IsPrivateChat { get; set; }
    public bool IsOneToOneChat { get; set; }
    
    public List<ChatRoomUser> ChatRoomUsers { get; set; }
    public List<Message> Messages { get; set; }
}