using TaskManagerAPI.Models;

namespace TaskManagerAPI.Dtos;

public class TaskFilterDto
{
    public TaskPriority? TaskPriority { get; set; }
    public string? TaskTitle { get; set; }
    public string? TaskDescription { get; set; }
}