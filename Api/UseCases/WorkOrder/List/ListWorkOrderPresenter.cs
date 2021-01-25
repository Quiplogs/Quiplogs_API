using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.WorkOrder.List
{
    public class ListWorkOrderPresenter : IOutputPort<ListWorkOrderResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListWorkOrderPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListWorkOrderResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
