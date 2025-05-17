using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Commands;
using TaskManagement.DAL;

namespace TaskManagement.Application.Handlers
{
    public class TaskCommandHandler
    {
        private readonly TaskDbContext _context;

        public TaskCommandHandler(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.TaskInfo
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                AssignedToUserId = request.AssignedToUserId,
                CreatedByUserId = request.CreatedByUserId,
                TeamId = request.TeamId,
                DueDate = request.DueDate
            };

            _context.TaskInfos.Add(task);
            await _context.SaveChangesAsync(cancellationToken);
            return task.Id;
        }

        public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
        {
            private readonly TaskDbContext _context;
            public UpdateTaskCommandHandler(TaskDbContext context) => _context = context;

            public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
            {
                var task = await _context.TaskInfos.FindAsync(request.Id);
                if (task == null) return false;

                task.Title = request.Title;
                task.Description = request.Description;
                task.Status = request.Status;
                task.AssignedToUserId = request.AssignedToUserId;
                task.TeamId = request.TeamId;
                task.DueDate = request.DueDate;

                await _context.SaveChangesAsync();
                return true;
            }
        }

        // DeleteTaskCommandHandler.cs
        public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
        {
            private readonly TaskDbContext _context;
            public DeleteTaskCommandHandler(TaskDbContext context) => _context = context;

            public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
            {
                var task = await _context.TaskInfos.FindAsync(request.Id);
                if (task == null) return false;

                _context.TaskInfos.Remove(task);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
