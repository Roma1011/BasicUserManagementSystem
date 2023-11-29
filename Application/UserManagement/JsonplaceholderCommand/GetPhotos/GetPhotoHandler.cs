using Application.Shared.JsonplaceholderObjects;
using Domain.Abstractions;
using Domain.IServices.ISecuriyServices;
using MediatR;
using Newtonsoft.Json;

namespace Application.UserManagement.JsonplaceholderCommand.GetPhotos;

public class GetPhotoHandler:IRequestHandler<GetPhotoCommand,List<Photo>>
{
    private readonly IHttpClientFactory _factory;
    public GetPhotoHandler(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<Photo>> Handle(GetPhotoCommand request, CancellationToken cancellationToken)
    {
        using (HttpClient httpClient = _factory.CreateClient())
        {
            HttpResponseMessage httpResponseMessage =
                await httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos", cancellationToken);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var posts = JsonConvert.DeserializeObject<List<Photo>>(
                    await httpResponseMessage.Content.ReadAsStringAsync());
                var res = posts.Where(i => i.AlbumId == request.UserId).ToList();
                return res;
            }
        }
        throw new InvalidOperationException();
    }
}