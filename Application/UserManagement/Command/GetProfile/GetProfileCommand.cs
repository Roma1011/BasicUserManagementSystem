using Application.Shared;
using MediatR;

namespace Application.UserManagement.Command.GetProfile;

public record GetProfileCommand(int ?UserId,string? UserEmail):IRequest<Shared.GetProfile>;