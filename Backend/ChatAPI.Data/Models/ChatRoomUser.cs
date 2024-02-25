namespace ChatAPI.Data.Models;

public class ChatRoomUser
{
    public int ChatRoomId { get; set; }
    
    public int UserId { get; set; }
    
    public string Description { get; set; }
}