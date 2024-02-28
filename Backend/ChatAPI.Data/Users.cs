using Microsoft.AspNetCore.Identity;

namespace ChatAPI.Data;

public class Users : IdentityUser<int>
{
    public Users()
    {
        DisplayName = default!;
    }
    //Id, UserName,Password and Email will come from base class in dotnet
    
    public string DisplayName { get; set; }
}