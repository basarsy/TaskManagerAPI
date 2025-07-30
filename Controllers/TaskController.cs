using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskManagerAPI.Dtos;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TaskController : ControllerBase
{
    private readonly AppDbContext _context;

    public TaskController(AppDbContext context)
    {
        _context = context;
    }
    
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
                TaskCreatedAt = t.TaskCreatedAt
            }).ToList();
        return Ok(tasks);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetTasks(int id)
    {
        var task = _context.Tasks
            .Where(t => t.TaskId == id)
            .Select(t => new TaskDetailsDto()
            {
                TaskId = t.TaskId,
                TaskTitle = t.TaskTitle,
                TaskDescription = t.TaskDescription,
                IsTaskCompleted = t.IsTaskCompleted,
                TaskCreatedAt = t.TaskCreatedAt
            })
            .FirstOrDefault();
        
        if (task == null)
        {
            return NotFound($"Task with id {id} not found");
        }
        return Ok(task);
    }
    

    [HttpPost]
    public IActionResult CreateTask(CreateTaskDto createDto)
    {
        var task = new TaskItem()
        {
            TaskTitle = createDto.TaskTitle,
            TaskDescription = createDto.TaskDescription,
            IsTaskCompleted = false,
            TaskCreatedAt = DateTime.UtcNow
        };

        _context.Tasks.Add(task);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTasks), new {id = task.TaskId}, task);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateTask(int id, UpdateTaskDto updateDto)
    {
        var task = _context.Tasks.FirstOrDefault(x => x.TaskId == id);
        task.TaskTitle = updateDto.TaskTitle;
        task.TaskDescription = updateDto.TaskDescription;
        task.IsTaskCompleted = updateDto.IsTaskCompleted;
        
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTasks), new {id = task.TaskId}, task);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _context.Tasks.FirstOrDefault(x => x.TaskId == id);
        if (task == null)
        {
            return NotFound($"Task with id {id} not found");
        }
        
        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return Ok($"Task with id {id} has been deleted");
    }

    [HttpPatch]
    [Route("{id}/complete")]
    public IActionResult CompleteTask(bool isCompleted, int id)
    {
        var task = _context.Tasks.FirstOrDefault(x => x.TaskId == id);
        if (task == null)
        {
            return NotFound($"Task with id {id} not found");
        }
        if (task.IsTaskCompleted)
        {
            return BadRequest($"Task with id {id} is already completed");
        }

        task.IsTaskCompleted = true;
        _context.SaveChanges();
        
        return Ok($"Task with id {id} has been completed");
    }
    //[HttpGet]
    public IActionResult FilterTasks(string filter)
    {
        var tasks = _context.Tasks.Where(x => x.TaskTitle.Contains(filter)).ToList();
        return Ok(tasks);
    }
}