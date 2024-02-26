using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Data.Models;

public class Message : BaseEntity
{
    //[MaxLength (500)] add fluent validation on Dbcontext
    public string Text { get; set; }
    public int SenderId { get; set; }
    public int ChatRoomId { get; set; }

    public List<ChatRoom> ChatRooms { get; set; }
    public List<ChatRoomUser> ChatRoomUsers { get; set; }

}