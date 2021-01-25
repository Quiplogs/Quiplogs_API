using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.PlannedMaintenance.List
{
    public class ListPlannedMaintenancePresenter : IOutputPort<ListPlannedMaintenanceResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListPlannedMaintenancePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListPlannedMaintenanceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
