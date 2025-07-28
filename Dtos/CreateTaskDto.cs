using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Dtos;

public class CreateTaskDto
{
    [Required]
    [MaxLength(20)]
    public required string TaskTitle { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string TaskDescription { get; set; }
}