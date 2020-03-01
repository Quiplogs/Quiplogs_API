using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;
using System.Net;

namespace Api.UseCases.WorkOrderPart.List
{
    public class ListWorkOrderPartPresenter : IOutputPort<ListWorkOrderPartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListWorkOrderPartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListWorkOrderPartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
