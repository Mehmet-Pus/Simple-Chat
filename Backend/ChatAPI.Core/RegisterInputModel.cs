namespace ChatAPI.Core;

public class RegisterInputModel
{
    public RegisterInputModel()
    {
        UserName = default!;
        Password = default!;
        Email = default!;
    }
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
}