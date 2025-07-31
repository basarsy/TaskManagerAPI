using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskManagerAPI.Dtos;

namespace TaskManagerAPI.Controllers;

[Route("api/{controller}")]
[ApiController]

public class TestController : ControllerBase
{
    
    private readonly AppDbContext _context;

    public TestController(AppDbContext context)
    {
        _context = context;
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult GetTasks()
    {
        var tasks = _context.Tasks
            .Select(t => new TaskDetailsDto()
            {
                TaskId = t.TaskId,
                TaskTitle = t.TaskTitle,
                TaskDescription = t.TaskDescription,
                IsTaskCompleted = t.IsTaskCompleted,
                TaskCreatedAt = t.TaskCreatedAt,
                TaskPriority = t.TaskPriority
            })
            .ToList();
        return Ok(tasks);
    }
}