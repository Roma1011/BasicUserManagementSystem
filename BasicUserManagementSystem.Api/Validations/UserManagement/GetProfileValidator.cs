using BasicUserManagementSystem.Models.Auth;
using BasicUserManagementSystem.Models.UserManagement;
using FluentValidation;

namespace BasicUserManagementSystem.Validations.UserManagement;

public class GetProfileValidator:AbstractValidator<UserProfile>
{
    public GetProfileValidator()
    {
        RuleFor(user => user)
            .Must(user => user.UserId != null || !string.IsNullOrWhiteSpace(user.UserEmail))
            .WithMessage("At least one field (UserId or UserEmail) must be filled");

    }
}