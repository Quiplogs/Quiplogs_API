using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Equipment.Put
{
    public class PutEquipmentPresenter : IOutputPort<PutEquipmentResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutEquipmentPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutEquipmentResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Equipment) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
