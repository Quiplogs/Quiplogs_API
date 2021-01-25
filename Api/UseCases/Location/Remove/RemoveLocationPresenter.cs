using Api.Presenters;
using Api.Serialization;
using System.Net;
using Quiplogs.Core.Dto.Responses.Location;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.Location.Remove
{
    public class RemoveLocationPresenter : IOutputPort<RemoveLocationResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveLocationPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveLocationResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
