using Application.Shared;
using MediatR;

namespace Application.UserManagement.Command.GetProfile;

public record GetProfileCommand(int UserId):IRequest<Shared.GetProfile>;