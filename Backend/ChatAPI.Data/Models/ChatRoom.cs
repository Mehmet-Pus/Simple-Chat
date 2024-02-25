namespace ChatAPI.Data.Models;

public class ChatRoom
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public bool IsPrivateChat { get; set; }
    
    public bool IsOneToOneChat { get; set; }
}