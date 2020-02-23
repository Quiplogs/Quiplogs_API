using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Inventory.Dto.Responses.Part;
using System.Net;

namespace Api.UseCases.Part.List
{
    public class ListPartPresenter : IOutputPort<ListPartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListPartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListPartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
