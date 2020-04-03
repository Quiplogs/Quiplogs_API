using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Location.Put
{
    public class PutLocationPresenter : IOutputPort<PutLocationResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutLocationPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutLocationResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Location) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
