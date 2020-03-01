using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;
using System.Net;

namespace Api.UseCases.WorkOrderPart.Put
{
    public class PutWorkOrderPartPresenter : IOutputPort<PutWorkOrderPartResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutWorkOrderPartPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutWorkOrderPartResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.WorkOrderPart) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
