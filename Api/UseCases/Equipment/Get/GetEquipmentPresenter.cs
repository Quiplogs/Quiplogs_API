using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Equipment.Get
{
    public class GetEquipmentPresenter : IOutputPort<GetEquipmentResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetEquipmentPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetEquipmentResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Equipment) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
