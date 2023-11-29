using MediatR;

namespace Application.UserManagement.UserManagementRootCommand.DeactiveProfile;

public record DeactiveProfileCommand(int UserId,string UserEmail):IRequest<bool>;