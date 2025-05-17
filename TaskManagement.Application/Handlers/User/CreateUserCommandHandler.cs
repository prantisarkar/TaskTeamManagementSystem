using MediatR;
using TaskManagement.Application.Commands.User;
using TaskManagement.DAL;

namespace TaskManagement.Application.Handlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly TaskDbContext _context;

        public CreateUserCommandHandler(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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
    }
}