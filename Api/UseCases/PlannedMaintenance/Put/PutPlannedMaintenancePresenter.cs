using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using System.Net;

namespace Api.UseCases.PlannedMaintenance.Put
{
    public class PutPlannedMaintenancePresenter : IOutputPort<PutPlannedMaintenanceResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutPlannedMaintenancePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutPlannedMaintenanceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PlannedMaintenance) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
