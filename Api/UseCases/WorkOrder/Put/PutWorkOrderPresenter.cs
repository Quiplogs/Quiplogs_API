using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.WorkOrder.Put
{
    public class PutWorkOrderPresenter : IOutputPort<PutWorkOrderResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutWorkOrderPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutWorkOrderResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.WorkOrder) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
