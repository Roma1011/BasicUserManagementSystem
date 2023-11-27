using MediatR;

namespace Application.Auth.Command;

public record AuthUserCommand:IRequest<int>
{
    
}