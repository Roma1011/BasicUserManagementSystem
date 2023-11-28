using BasicUserManagementSystem.Models.Auth;
using BasicUserManagementSystem.Models.UserManagement;
using FluentValidation;

namespace BasicUserManagementSystem.Validations.UserManagement;

public class GetProfileValidator:AbstractValidator<UserProfile>
{
    public GetProfileValidator()
    {
        RuleFor(user => user.UserId)
            .NotNull()
            .WithMessage("UserId is required.");
        RuleFor(user => user.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");
    }
}