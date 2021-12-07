using Api.Presenters;
using Api.Serialization;
using System.Net;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.User.Fetch
{
    public class FetchUsersPresenter : IOutputPort<FetchUsersResponse>
    {
        public JsonContentResult ContentResult { get; }

        public FetchUsersPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(FetchUsersResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
