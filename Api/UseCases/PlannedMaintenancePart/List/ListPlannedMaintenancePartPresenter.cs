using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.PlannedMaintenancePart.List
{
    public class ListPlannedMaintenancePartPresenter : IOutputPort<ListPlannedMaintenancePartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListPlannedMaintenancePartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListPlannedMaintenancePartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PlannedMaintenanceParts) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
