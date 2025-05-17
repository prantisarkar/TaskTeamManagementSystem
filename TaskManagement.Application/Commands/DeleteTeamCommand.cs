using MediatR;

namespace TaskManagement.Application.Commands;

public class DeleteTeamCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteTeamCommand(Guid id)
    {
        Id = id;
    }
}
