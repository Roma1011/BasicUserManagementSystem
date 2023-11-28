using MediatR;

namespace Application.Auth.Command;

public record AuthUserCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}