namespace TaskManagerAPI.Dtos;

public class TaskDetailsDto
{
    public int TaskId { get; set; }
    public required string TaskTitle { get; set; }
    public required string TaskDescription { get; set; }
    public bool IsTaskCompleted { get; set; }
    public DateTime TaskCreatedAt { get; set; }
}