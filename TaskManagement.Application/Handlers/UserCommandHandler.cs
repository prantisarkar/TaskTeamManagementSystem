using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Commands;
using TaskManagement.Application.Queries;
using TaskManagement.DAL;

namespace TaskManagement.Application.Handlers
{
    public class UserCommandHandler : IRequestHandler<UserCommand, Guid>
    {
        private readonly TaskDbContext _context;

        public UserCommandHandler(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                Role = request.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

        public class GetAllUsersQueryHandler : IRequestHandler<UsersQuery, List<Domain.User>>
        {
            private readonly TaskDbContext _context;

            public GetAllUsersQueryHandler(TaskDbContext context)
            {
                _context = context;
            }

            public async Task<List<Domain.User>> Handle(UsersQuery request, CancellationToken cancellationToken)
            {
                // Corrected to use asynchronous EF Core method
                return await _context.Users.ToListAsync(cancellationToken);
            }
        }
    }
}