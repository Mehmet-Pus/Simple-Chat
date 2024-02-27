using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Data.Models;

public class Message : BaseEntity
{
    public string Text { get; set; }
    public int SenderId { get; set; }
    public int ChatRoomId { get; set; }

    public ChatRoom ChatRoom { get; set; }
}