using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;
using System.Net;

namespace Api.UseCases.WorkOrderTask.Put
{
    public class PutWorkOrderTaskPresenter : IOutputPort<PutWorkOrderTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutWorkOrderTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutWorkOrderTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.WorkOrderTask) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
