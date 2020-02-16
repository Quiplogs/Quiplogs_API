using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Location.List
{
    public class ListLocationPresenter : IOutputPort<ListLocationResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListLocationPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListLocationResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
