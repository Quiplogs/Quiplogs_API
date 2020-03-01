using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using System.Net;

namespace Api.UseCases.PlannedMaintenance.Remove
{
    public class RemovePlannedMaintenancePresenter : IOutputPort<RemovePlannedMaintenanceResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemovePlannedMaintenancePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemovePlannedMaintenanceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
