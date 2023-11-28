using System.Text.RegularExpressions;
using BasicUserManagementSystem.Models.Auth;
using FluentValidation;

namespace BasicUserManagementSystem.Validations.Auth;

public class AuthModelValidator:AbstractValidator<AuthModel>
{
    public AuthModelValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .Must(BeAllowedEmailDomain).WithMessage("Invalid email domain.");
    }
    private bool BeAllowedEmailDomain(string email)
    {
        string pattern = @"@(gmail\.com|yahoo\.com|example\.com)$";
        return Regex.IsMatch(email, pattern);
    }
}