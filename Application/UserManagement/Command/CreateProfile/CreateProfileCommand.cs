using Application.Shared;
using MediatR;

namespace Application.UserManagement.Command.CreateProfile
{
    public record CreateProfileCommand(DynamicProfileDto ProfileDto) : IRequest<bool>;
}