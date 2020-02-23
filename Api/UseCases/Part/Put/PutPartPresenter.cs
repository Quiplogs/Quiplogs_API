using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Inventory.Dto.Responses.Part;
using System.Net;

namespace Api.UseCases.Part.Put
{
    public class PutPartPresenter : IOutputPort<PutPartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutPartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutPartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Part) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
