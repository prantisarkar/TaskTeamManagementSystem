using MediatR;
using TaskManagement.Domain;
using System;

namespace TaskManagement.Application.Commands.User
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}