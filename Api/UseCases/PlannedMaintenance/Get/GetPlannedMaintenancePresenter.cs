using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using System.Net;

namespace Api.UseCases.PlannedMaintenance.Get
{
    public class GetPlannedMaintenancePresenter : IOutputPort<GetPlannedMaintenanceResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetPlannedMaintenancePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetPlannedMaintenanceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PlannedMaintenance) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
