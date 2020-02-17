using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Service.List
{
    public class ListServicePresenter : IOutputPort<ListServiceResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListServicePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListServiceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
