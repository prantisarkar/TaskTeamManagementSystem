using MediatR;
using System;

namespace TaskManagement.Application.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
