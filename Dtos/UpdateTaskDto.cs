namespace TaskManagerAPI.Dtos;

public class UpdateTaskDto
{
    public required string TaskTitle { get; set; }
    public required string TaskDescription { get; set; }
    public bool IsTaskCompleted { get; set; }
}