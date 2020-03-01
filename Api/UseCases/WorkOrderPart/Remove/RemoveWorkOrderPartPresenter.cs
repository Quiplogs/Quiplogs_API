using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;
using System.Net;

namespace Api.UseCases.WorkOrderPartPart.Remove
{
    public class RemoveWorkOrderPartPresenter : IOutputPort<RemoveWorkOrderPartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveWorkOrderPartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveWorkOrderPartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
