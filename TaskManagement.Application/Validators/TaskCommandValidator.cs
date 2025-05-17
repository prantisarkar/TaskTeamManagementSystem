using FluentValidation;
using TaskManagement.Application.Commands;

namespace TaskManagement.Application.Validators;

public class TaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public TaskCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
        RuleFor(x => x.Status).Must(s => new[] { "Todo", "InProgress", "Done" }.Contains(s));
        RuleFor(x => x.DueDate).GreaterThan(DateTime.UtcNow);
    }
}