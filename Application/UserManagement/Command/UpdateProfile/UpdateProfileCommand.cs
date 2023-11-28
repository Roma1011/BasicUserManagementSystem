using Application.Shared;
using MediatR;

namespace Application.UserManagement.Command.UpdateProfile;

public record UpdateProfileCommand(int Id,DynamicProfileDto ProfileDto) : IRequest<bool>;