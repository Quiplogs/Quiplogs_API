using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Inventory.Dto.Responses.Part;
using System.Net;

namespace Api.UseCases.Part.Remove
{
    public class RemovePartPresenter : IOutputPort<RemovePartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemovePartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemovePartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
