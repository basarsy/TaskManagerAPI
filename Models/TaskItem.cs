using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models;
public enum TaskPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
}
public class TaskItem
{
    [Key]
    public int TaskId { get; set; }
    [MaxLength(20)]
    public string TaskTitle { get; set; }
    [MaxLength(100)]
    public string TaskDescription { get; set; }
    public bool IsTaskCompleted { get; set; }
    public DateTime TaskCreatedAt { get; set; }
    public TaskPriority? TaskPriority { get; set; }
    public int? UserId { get; set; }
    
}