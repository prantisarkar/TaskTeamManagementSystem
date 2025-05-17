using FluentValidation;
using TaskManagement.Application.Commands;

namespace TaskManagement.Application.Validators;

public class TeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    public TeamCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(250);
    }
}