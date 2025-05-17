using MediatR;
using System;

namespace TaskManagement.Application.Commands
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}
