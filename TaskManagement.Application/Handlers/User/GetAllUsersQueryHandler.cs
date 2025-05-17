using MediatR;
using TaskManagement.DAL;

using TaskManagement.Application.Queries.User;

namespace TaskManagement.Application.Handlers.User
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<Domain.User>>
    {
        private readonly TaskDbContext _context;

        public GetAllUsersQueryHandler(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Users.ToList());
        }
    }
}