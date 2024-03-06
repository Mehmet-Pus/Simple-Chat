using ChatAPI.Core.Models;
using ChatAPI.Data.Models;
using ChatAPI.Startup.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Startup.Controllers;

[AllowAnonymous]
[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public AuthController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginInputModel model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateToken(user, roles);

            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterInputModel model)
    {
        var appUser = new User();
        appUser.UserName = model.UserName;
        appUser.Email = model.Email;
        appUser.DisplayName = model.DisplayName;
        var user = await _userManager.CreateAsync(appUser, model.Password);

        return Ok();
    }
    
}