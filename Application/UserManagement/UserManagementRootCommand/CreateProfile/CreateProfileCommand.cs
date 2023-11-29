using Application.Shared;
using MediatR;

namespace Application.UserManagement.UserManagementRootCommand.CreateProfile
{
    public record CreateProfileCommand(DynamicProfileDto ProfileDto) : IRequest<bool>;
}