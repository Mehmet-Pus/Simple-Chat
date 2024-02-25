using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Data.Models;

public class Message
{
    public int Id { get; set; }
    
    [MaxLength (500)]
    public string Text { get; set; }
    
    public int SenderId { get; set; }
    
    public int ChatRoomId { get; set; }
}