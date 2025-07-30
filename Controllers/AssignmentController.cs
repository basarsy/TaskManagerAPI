using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskManagerAPI.Dtos;

namespace TaskManagerAPI.Controllers;

[Route("api/{controller}")]
[ApiController ]

public class AssignmentController : ControllerBase
{
    private readonly AppDbContext _context;
    public AssignmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPatch("{taskId}/assign")]
    public IActionResult AssignTask([FromRoute] int taskId, [FromBody] TaskManageDto taskDto)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
        if (task == null)
        {
            return NotFound($"Task with id {taskId} not found");
        }
        
        var user = _context.Users.FirstOrDefault(u => u.UserId == taskDto.UserId);
        if (user == null)
        {
            return NotFound($"User with id {taskDto.UserId} not found");
        }

        task.UserId = taskDto.UserId;
        _context.SaveChanges();
        
        return Ok($"Task with id {taskId} has been assigned to user with id {taskDto.UserId}");
    }
    
    [HttpDelete("{taskId}/unassign")]
    public IActionResult UnassignTask([FromRoute] int taskId)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
        if (task == null)
        {
            return NotFound($"Task with id {taskId} not found");
        }
        
        task.UserId = null;
        _context.SaveChanges();
        return Ok($"Task with id {taskId} has been unassigned");
    }
}