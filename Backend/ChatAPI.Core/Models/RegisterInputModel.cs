namespace ChatAPI.Core.Models;

public class RegisterInputModel
{
    public RegisterInputModel()
    {
        UserName = default!;
        Password = default!;
        Email = default!;
        DisplayName = default!;
    }
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    public string DisplayName { get; set; }
}