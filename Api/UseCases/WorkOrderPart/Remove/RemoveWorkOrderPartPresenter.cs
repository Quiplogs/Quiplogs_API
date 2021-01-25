using System.Net;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;

namespace Api.UseCases.WorkOrderPart.Remove
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
