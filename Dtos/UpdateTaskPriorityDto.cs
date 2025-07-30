using TaskManagerAPI.Models;

namespace TaskManagerAPI.Dtos;

public class UpdateTaskPriorityDto
{
    public TaskPriority TaskPriority { get; set; }
}