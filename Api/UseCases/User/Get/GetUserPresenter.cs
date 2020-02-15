using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.User.Get
{
    public sealed class GetUserPresenter : IOutputPort<GetUserResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetUserResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.User) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
