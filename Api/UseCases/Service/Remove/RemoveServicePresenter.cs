using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Service.Remove
{
    public class RemoveServicePresenter : IOutputPort<RemoveServiceResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveServicePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveServiceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
