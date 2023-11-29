using Application.Shared.JsonplaceholderObjects;
using Application.UserManagement.JsonplaceholderCommand.GetPhotos;
using Domain.Abstractions;
using Domain.IServices.ISecuriyServices;
using MediatR;
using Newtonsoft.Json;

namespace Application.UserManagement.JsonplaceholderCommand.GetComments;

public class GetCommentHandler:IRequestHandler<GetCommentCommand,List<Comment>>
{
    private readonly IHttpClientFactory _factory;
    public GetCommentHandler(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<Comment>> Handle(GetCommentCommand request, CancellationToken cancellationToken)
    {
        using (HttpClient httpClient = _factory.CreateClient())
        {
            HttpResponseMessage httpResponseMessage =
                await httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments", cancellationToken);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var posts = JsonConvert.DeserializeObject<List<Comment>>(
                    await httpResponseMessage.Content.ReadAsStringAsync());
                var res = posts.Where(i => i.PostId == request.UserId).ToList();
                return res;
            }
        }
        throw new InvalidOperationException();
    }
}