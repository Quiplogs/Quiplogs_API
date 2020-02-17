using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Service.Get
{
    public class GetServicePresenter : IOutputPort<GetServiceResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetServicePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetServiceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Service) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
