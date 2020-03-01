using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;
using System.Net;

namespace Api.UseCases.WorkOrderTask.List
{
    public class ListWorkOrderTaskPresenter : IOutputPort<ListWorkOrderTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListWorkOrderTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListWorkOrderTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
