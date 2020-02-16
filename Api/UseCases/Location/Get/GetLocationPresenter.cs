using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Location.Get
{
    public class GetLocationPresenter : IOutputPort<GetLocationResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetLocationPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetLocationResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Location) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
