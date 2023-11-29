using Application.Shared;
using MediatR;

namespace Application.UserManagement.UserManagementRootCommand.UpdateProfile;

public record UpdateProfileCommand(DynamicProfileDto ProfileDto) : IRequest<bool>;