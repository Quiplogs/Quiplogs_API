using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

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
