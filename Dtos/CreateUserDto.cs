using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Dtos;

public class CreateUserDto
{
    [Required]
    [MaxLength(15)]
    public required string UserName { get; set; }
    
    [Required]
    [MaxLength(30)]
    public required string UserPassword { get; set; }
}