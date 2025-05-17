using FluentValidation;
using TaskManagement.Domain;

namespace TaskManagement.Application;

public class TeamValidator : AbstractValidator<Team>
{
    public TeamValidator()
    {
        RuleFor(team => team.Name)
            .NotEmpty().WithMessage("Team name is required.")
            .MaximumLength(50).WithMessage("Team name cannot exceed 50 characters.");

        RuleFor(team => team.Description)
            .MaximumLength(250).WithMessage("Description cannot exceed 250 characters.");
    }
}