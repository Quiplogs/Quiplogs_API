using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using System.Net;

namespace Api.UseCases.PlannedMaintenanceTask.List
{
    public class ListPlannedMaintenanceTaskPresenter : IOutputPort<ListPlannedMaintenanceTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListPlannedMaintenanceTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListPlannedMaintenanceTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
