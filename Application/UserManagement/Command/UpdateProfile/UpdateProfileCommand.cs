using Application.Shared;
using MediatR;

namespace Application.UserManagement.Command.UpdateProfile;

public record UpdateProfileCommand(DynamicProfileDto ProfileDto) : IRequest<bool>;