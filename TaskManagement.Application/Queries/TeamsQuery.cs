using MediatR;

namespace TaskManagement.Application.Queries
{
    public class TeamsQuery : IRequest<List<Domain.Team>> { }

    public class GetTeamByIdQuery : IRequest<Domain.Team>
    {
        public Guid Id { get; set; }
    }
}