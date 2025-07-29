using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models;

public class TaskItem
{
    [Key]
    public int TaskId { get; set; }
    [MaxLength(20)]
    public required string TaskTitle { get; set; }
    [MaxLength(100)]
    public required string TaskDescription { get; set; }
    public bool IsTaskCompleted { get; set; }
    public DateTime TaskCreatedAt { get; set; }
    
    public int? UserId { get; set; }
    public User? User { get; set; }
    
}