using Application.Shared.JsonplaceholderObjects;
using MediatR;

namespace Application.UserManagement.JsonplaceholderCommand.GetComments;

public record GetCommentCommand(int UserId) : IRequest<List<Comment>>;
