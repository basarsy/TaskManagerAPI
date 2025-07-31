using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskManagerAPI.Dtos;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers;

[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    
    private readonly JwtTokenService _tokenService;

    public AuthController(AppDbContext context, IConfiguration config, JwtTokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserAuthDto authDto)
    {
        var user = _context.Users.SingleOrDefault(u => u.UserName == authDto.UserName);
        if (user == null)
        {
            return Unauthorized();
        }

        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.UserPassword, authDto.UserPassword);
        if (result == PasswordVerificationResult.Failed)
        {
            return Unauthorized();
        }

        var token = _tokenService.GenerateToken();
        return Ok(new { token });
    }
}