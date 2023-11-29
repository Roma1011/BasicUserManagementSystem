using Application.Shared.JsonplaceholderObjects;
using Application.UserManagement.JsonplaceholderCommand.GetPhotos;
using Domain.Abstractions;
using Domain.IServices.ISecuriyServices;
using MediatR;
using Newtonsoft.Json;

namespace Application.UserManagement.JsonplaceholderCommand.GetPosts;

public class GetPostHandler : IRequestHandler<GetPostCommand, List<Post>>
{
    private readonly IHttpClientFactory _factory;

    public GetPostHandler(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<Post>> Handle(GetPostCommand request, CancellationToken cancellationToken)
    {
        using (HttpClient httpClient = _factory.CreateClient())
        {
            HttpResponseMessage httpResponseMessage =
                await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts", cancellationToken);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var posts = JsonConvert.DeserializeObject<List<Post>>(
                    await httpResponseMessage.Content.ReadAsStringAsync());
                var res = posts.Where(i => i.UserId == request.UserId).ToList();
                return res;
            }
        }
        throw new InvalidOperationException();
    }
}