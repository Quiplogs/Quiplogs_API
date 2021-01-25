using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.WorkOrderTask.Remove
{
    public class RemoveWorkOrderTaskPresenter : IOutputPort<RemoveWorkOrderTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveWorkOrderTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveWorkOrderTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
