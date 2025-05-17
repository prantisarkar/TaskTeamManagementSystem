using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Commands;
using TaskManagement.Application.Queries;
using TaskManagement.DAL;
using TaskManagement.Domain;

namespace TaskManagement.Application.Handlers
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly TaskDbContext _context;

        public UserCommandHandler(TaskDbContext context)
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

        // CreateUserCommandHandler.cs
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
        {
            private readonly TaskDbContext _context;
            public CreateUserCommandHandler(TaskDbContext context) => _context = context;

            public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    FullName = request.FullName,
                    Email = request.Email,
                    Role = request.Role
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
        }

        // UpdateUserCommandHandler.cs
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
        {
            private readonly TaskDbContext _context;
            public UpdateUserCommandHandler(TaskDbContext context) => _context = context;

            public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);
                if (user == null) return false;

                user.FullName = request.FullName;
                user.Email = request.Email;
                user.Role = request.Role;

                await _context.SaveChangesAsync();
                return true;
            }
        }

        // DeleteUserCommandHandler.cs
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
        {
            private readonly TaskDbContext _context;
            public DeleteUserCommandHandler(TaskDbContext context) => _context = context;

            public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);
                if (user == null) return false;

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}