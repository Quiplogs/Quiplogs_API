using Api.Core.Dto.Responses.Equipment;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Equipment.Remove
{
    public class RemoveEquipmentPresenter : IOutputPort<RemoveEquipmentResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveEquipmentPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveEquipmentResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
