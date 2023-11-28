using MediatR;

namespace Application.UserManagement.Command.DeactiveProfile;

public record DeactiveProfileCommand(int UserId):IRequest<bool>;