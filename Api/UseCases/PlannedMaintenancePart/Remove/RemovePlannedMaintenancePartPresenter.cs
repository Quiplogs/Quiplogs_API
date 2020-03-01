using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using System.Net;

namespace Api.UseCases.PlannedMaintenancePart.Remove
{
    public class RemovePlannedMaintenancePartPresenter : IOutputPort<RemovePlannedMaintenancePartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemovePlannedMaintenancePartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemovePlannedMaintenancePartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
