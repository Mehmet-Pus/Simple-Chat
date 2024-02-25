namespace ChatAPI.Data.Models;

public class Users
{
    public int Id { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string EMail { get; set; }
    
    public string DisplayName { get; set; }
}