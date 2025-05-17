using MediatR;
using System;

namespace TaskManagement.Application.Commands
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid AssignedToUserId { get; set; }
        public Guid TeamId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
