using MediatR;


namespace TaskManagement.Application.Queries
{
    public class TasksQuery : IRequest<List<Domain.TaskInfo>>
    {
        public string? Status { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public Guid? TeamId { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class GetTaskByIdQuery : IRequest<Domain.TaskInfo>
    {
        public Guid Id { get; set; }
    }
}