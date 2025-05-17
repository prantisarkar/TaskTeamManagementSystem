
using MediatR;
using TaskManagement.Application.Commands;
using TaskManagement.DAL;
using TaskManagement.Domain;

namespace TaskManagement.Application.Handlers;

public class TeamCommandHandler : IRequestHandler<CreateTeamCommand, Guid>
{
    private readonly TaskDbContext _context;
    public TeamCommandHandler(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
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

    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Guid>
    {
        private readonly TaskDbContext _context;
        public CreateTeamCommandHandler(TaskDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team.Id;
        }
    }

    // UpdateTeamCommandHandler.cs
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, bool>
    {
        private readonly TaskDbContext _context;
        public UpdateTeamCommandHandler(TaskDbContext context) => _context = context;

        public async Task<bool> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _context.Teams.FindAsync(request.Id);
            if (team == null) return false;

            team.Name = request.Name;
            team.Description = request.Description;

            await _context.SaveChangesAsync();
            return true;
        }
    }

    // DeleteTeamCommandHandler.cs
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, bool>
    {
        private readonly TaskDbContext _context;
        public DeleteTeamCommandHandler(TaskDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _context.Teams.FindAsync(request.Id);
            if (team == null) return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}