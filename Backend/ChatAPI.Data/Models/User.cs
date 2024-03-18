using Microsoft.AspNetCore.Identity;

namespace ChatAPI.Data.Models;

public class User : IdentityUser<int>
{
    public User()
    {
        DisplayName = default!;
    }
    
    public string DisplayName { get; set; }
}