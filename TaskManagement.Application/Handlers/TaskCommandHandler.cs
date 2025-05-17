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

        public async Task<Guid> Handle(TaskCommand request, CancellationToken cancellationToken)
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
    }
}
