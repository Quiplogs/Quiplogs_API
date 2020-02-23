using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Inventory.Dto.Responses.Task;
using System.Net;

namespace Api.UseCases.Task.List
{
    public class ListTaskPresenter : IOutputPort<ListTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
