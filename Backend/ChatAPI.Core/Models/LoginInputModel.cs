namespace ChatAPI.Core.Models;

public class LoginInputModel
{
    public LoginInputModel()
    {
        UserName = default!;
        Password = default!;
    }
    public string UserName { get; set; }
    public string Password { get; set; }
}