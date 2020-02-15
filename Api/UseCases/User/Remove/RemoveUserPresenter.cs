using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.User.Remove
{
    public sealed class RemoveUserPresenter : IOutputPort<RemoveUserResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveUserResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Name) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
