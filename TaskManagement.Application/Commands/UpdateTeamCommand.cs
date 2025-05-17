using MediatR;
using System;

namespace TaskManagement.Application.Commands
{
    public class UpdateTeamCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
