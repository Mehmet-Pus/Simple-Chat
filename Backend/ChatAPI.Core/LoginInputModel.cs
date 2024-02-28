namespace ChatAPI.Core;

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