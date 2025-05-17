using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; } // Admin, Manager, Employee
}