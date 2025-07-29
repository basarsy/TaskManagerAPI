namespace TaskManagerAPI.Dtos;

public class UpdateUserDto
{
    public required string UserName { get; set; }
    
    public required string UserPassword { get; set; }
    
}