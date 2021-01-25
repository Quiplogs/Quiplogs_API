using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.WorkOrder.Remove
{
    public class RemoveWorkOrderPresenter : IOutputPort<RemoveWorkOrderResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveWorkOrderPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveWorkOrderResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
