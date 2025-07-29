using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    public string UserName { get; set; }
    
    public string UserPassword { get; set; }
    
}