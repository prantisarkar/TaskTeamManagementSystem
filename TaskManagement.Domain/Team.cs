using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain;

public class Team
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public string Description { get; set; }
}