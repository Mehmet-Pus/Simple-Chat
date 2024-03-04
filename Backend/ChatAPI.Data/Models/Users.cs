using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ChatAPI.Data.Models;

public class Users : IdentityUser<int>
{
    public Users()
    {
        DisplayName = default!;
    }
    
    [MaxLength(20)]
    public string DisplayName { get; set; }
}