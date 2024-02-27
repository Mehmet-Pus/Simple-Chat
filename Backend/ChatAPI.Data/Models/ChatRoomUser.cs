using ChatAPI.Core;

namespace ChatAPI.Data.Models;

public class ChatRoomUser : BaseEntity
{

    public ChatRoomUser()
    {
        Description = default!;
        ChatRoom = default!;
    }
    
    public int ChatRoomId { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    
    public ChatRoom ChatRoom { get; set; }
    //public User Sender will be implemented along with auth 
}