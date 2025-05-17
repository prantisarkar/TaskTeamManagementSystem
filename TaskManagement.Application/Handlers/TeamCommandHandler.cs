
using MediatR;
using TaskManagement.Application.Commands;
using TaskManagement.DAL;

namespace TaskManagement.Application.Handlers;

public class TeamCommandHandler : IRequestHandler<TeamCommand, Guid>
{
    private readonly TaskDbContext _context;
    public TeamCommandHandler(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(TeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Domain.Team
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };
        _context.Teams.Add(team);
        await _context.SaveChangesAsync(cancellationToken);
        return team.Id;
    }

    public class GetAllTeamsQueryHandler
    {
        public class GetAllTeamsQuery : IRequest<List<Domain.Team>> { }
    }
}