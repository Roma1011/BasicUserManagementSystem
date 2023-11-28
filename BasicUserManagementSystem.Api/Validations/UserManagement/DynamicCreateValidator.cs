using System.Text.RegularExpressions;
using BasicUserManagementSystem.Models.UserManagement;
using FluentValidation;

namespace BasicUserManagementSystem.Validations.UserManagement;

public class DynamicCreateValidator:AbstractValidator<DynamicProfileModel>
{
    public DynamicCreateValidator()
    {
        RuleFor(user=>user.UserName)
            .NotEmpty().WithMessage("UserName name is required.")
            .NotNull()
            .MinimumLength(10).WithMessage("UserName name not less 10 characters.")
            .MaximumLength(50).WithMessage("UserName name must not exceed 50 characters.");
        
        RuleFor(user=>user.Email)
            .Must(firstName => !string.IsNullOrWhiteSpace(firstName))
            .WithMessage("First name is required.")
            .MinimumLength(10).WithMessage("First name not less 10 characters.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
        
        RuleFor(user=>user.FirstName)
            .NotEmpty().WithMessage("UserName name is required.")
            .NotNull()
            .MinimumLength(1).WithMessage("UserName name not less 10 characters.")
            .MaximumLength(50).WithMessage("UserName name must not exceed 50 characters.");
        
        RuleFor(user=>user.LastName)
            .NotEmpty().WithMessage("LastName name is required.")
            .NotNull()
            .MinimumLength(1).WithMessage("LastName name not less 10 characters.")
            .MaximumLength(50).WithMessage("LastName name must not exceed 50 characters.");
        
        RuleFor(user=>user.Password)
            .NotEmpty().WithMessage("Password is required.")
            .NotNull()
            .MinimumLength(10).WithMessage("Password must not less 10 characters.")
            .MaximumLength(50).WithMessage("Password must not exceed 50 characters.");

        RuleFor(user => user.PersonalNumber)
            .NotEmpty().WithMessage("PersonalNumber is required.")
            .NotNull().WithMessage("PersonalNumber is required.")
            .GreaterThan(999_999_999).WithMessage("PersonalNumber must be at least 10 digits.");
    }
    private bool BeAllowedEmailDomain(string email)
    {
        string pattern = @"@(gmail\.com|yahoo\.com|example\.com)$";
        return Regex.IsMatch(email, pattern);
    }
}