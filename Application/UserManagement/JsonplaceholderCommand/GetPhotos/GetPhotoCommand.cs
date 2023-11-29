using Application.Shared;
using Application.Shared.JsonplaceholderObjects;
using MediatR;

namespace Application.UserManagement.JsonplaceholderCommand.GetPhotos;

public record GetPhotoCommand(int UserId) : IRequest<List<Photo>>;
