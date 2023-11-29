using Application.Shared.JsonplaceholderObjects;
using MediatR;

namespace Application.UserManagement.JsonplaceholderCommand.GetPosts;

public record GetPostCommand(int UserId):IRequest<List<Post>>;