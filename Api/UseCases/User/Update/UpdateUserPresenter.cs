using Api.Presenters;
using Api.Serialization;
using System.Net;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.User.Update
{
    public sealed class UpdateUserPresenter : IOutputPort<UpdateUserResponse>
    {
        public JsonContentResult ContentResult { get; }

        public UpdateUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(UpdateUserResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.User) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
