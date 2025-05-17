using FluentValidation;
using TaskManagement.Domain;

namespace TaskManagement.Application.Validators;

public class TaskInfoValidator : AbstractValidator<TaskInfo>
{
    public TaskInfoValidator()
    {
        RuleFor(task => task.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(task => task.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(task => task.Status)
            .NotEmpty().WithMessage("Status is required.")
            .Must(status => new[] { "Todo", "InProgress", "Done" }.Contains(status))
            .WithMessage("Status must be Todo, InProgress, or Done.");

        RuleFor(task => task.AssignedToUserId)
            .NotEqual(Guid.Empty).WithMessage("Assigned user is required.");

        RuleFor(task => task.CreatedByUserId)
            .NotEqual(Guid.Empty).WithMessage("Creator user is required.");

        RuleFor(task => task.TeamId)
            .NotEqual(Guid.Empty).WithMessage("Team is required.");

        RuleFor(task => task.DueDate)
            .GreaterThan(DateTime.UtcNow).WithMessage("Due date must be in the future.");
    }
}