using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;
using Api.Serialization;
using System.Net;

namespace Api.Presenters.Equipment
{
    public class FetchEquipmentPresenter : IOutputPort<FetchEquipmentResponse>
    {
        public JsonContentResult ContentResult { get; }

        public FetchEquipmentPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(FetchEquipmentResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
