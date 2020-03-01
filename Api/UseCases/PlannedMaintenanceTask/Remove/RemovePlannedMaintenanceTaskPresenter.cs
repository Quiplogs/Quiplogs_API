using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using System.Net;

namespace Api.UseCases.PlannedMaintenanceTask.Remove
{
    public class RemovePlannedMaintenanceTaskPresenter : IOutputPort<RemovePlannedMaintenanceTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemovePlannedMaintenanceTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemovePlannedMaintenanceTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
