using MediatR;

namespace TaskManagement.Application.Commands;

public class CreateTeamCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
