using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;
using System.Net;

namespace Api.UseCases.WorkOrder.Get
{
    public class GetWorkOrderPresenter : IOutputPort<GetWorkOrderResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetWorkOrderPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetWorkOrderResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.WorkOrder) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
