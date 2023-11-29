using MediatR;

namespace Application.UserManagement.UserManagementRootCommand.GetProfile;

public record GetProfileCommand(int ?UserId,string? UserEmail):IRequest<Shared.GetProfile>;