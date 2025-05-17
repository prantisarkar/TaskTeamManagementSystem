using FluentValidation;
using TaskManagement.Domain;

namespace TaskManagement.Application;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(user => user.Role)
            .NotEmpty().WithMessage("Role is required.")
            .Must(role => new[] { "Admin", "Manager", "Employee" }.Contains(role))
            .WithMessage("Role must be Admin, Manager, or Employee.");
    }
}