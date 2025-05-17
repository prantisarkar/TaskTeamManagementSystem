using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain;

public class Task
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } // Todo, InProgress, Done
    public Guid AssignedToUserId { get; set; }
    public Guid CreatedByUserId { get; set; }
    public Guid TeamId { get; set; }
    public DateTime DueDate { get; set; }
}