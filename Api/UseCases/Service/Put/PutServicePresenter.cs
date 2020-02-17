using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Service.Put
{
    public class PutServicePresenter : IOutputPort<PutServiceResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutServicePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutServiceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Service) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
