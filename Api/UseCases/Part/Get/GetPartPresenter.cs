using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Inventory.Dto.Responses.Part;
using System.Net;

namespace Api.UseCases.Part.Get
{
    public class GetPartPresenter : IOutputPort<GetPartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetPartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetPartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Part) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
