using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.PlannedMaintenanceTask.Put
{
    public class PutPlannedMaintenanceTaskPresenter : IOutputPort<PutPlannedMaintenanceTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutPlannedMaintenanceTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutPlannedMaintenanceTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PlannedMaintenanceTask) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
