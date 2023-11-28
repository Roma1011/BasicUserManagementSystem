using System.Text.RegularExpressions;
using BasicUserManagementSystem.Models.Auth;
using FluentValidation;

namespace BasicUserManagementSystem.Validations.Auth;

public class AuthModelValidator:AbstractValidator<AuthModel>
{
    public AuthModelValidator()
    {
        RuleFor(user=>user.Email)
            .Must(firstName => !string.IsNullOrWhiteSpace(firstName))
            .WithMessage("First name is required.")
            .MinimumLength(10).WithMessage("First name not less 10 characters.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
    }
    private bool BeAllowedEmailDomain(string email)
    {
        string pattern = @"@(gmail\.com|yahoo\.com|example\.com)$";
        return Regex.IsMatch(email, pattern);
    }
}