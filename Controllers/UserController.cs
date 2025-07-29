using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;

namespace TaskManagerAPI.Controllers;
using TaskManagerAPI.Models;
using TaskManagerAPI.Dtos;

[Route("api/user/{controller}")]
[ApiController]


public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetUser()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    [HttpGet]
    public IActionResult GetUser(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserDto createDto)
    {
        var user = new User()
        {
            UserName = createDto.UserName,
            UserPassword = createDto.UserPassword,
        };
        
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return NotFound($"User with id {id} not found");
        }
        
        _context.Users.Remove(user);
        _context.SaveChanges();
        return Ok($"User with id {id} has been deleted");
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateUser(int id, UpdateUserDto updateDto)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        user.UserName = updateDto.UserName;
        user.UserPassword = updateDto.UserPassword;
        
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
    }
}