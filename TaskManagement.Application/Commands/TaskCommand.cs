using MediatR;

namespace TaskManagement.Application.Commands;

public class TaskCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } = "Todo";
    public Guid AssignedToUserId { get; set; }
    public Guid CreatedByUserId { get; set; }
    public Guid TeamId { get; set; }
    public DateTime DueDate { get; set; }
}