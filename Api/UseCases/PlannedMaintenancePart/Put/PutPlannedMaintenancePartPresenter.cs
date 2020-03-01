using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using System.Net;

namespace Api.UseCases.PlannedMaintenancePart.Put
{
    public class PutPlannedMaintenancePartPresenter : IOutputPort<PutPlannedMaintenancePartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutPlannedMaintenancePartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutPlannedMaintenancePartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PlannedMaintenancePart) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
