using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Inventory.Dto.Responses.Task;
using System.Net;

namespace Api.UseCases.Task.Put
{
    public class PutTaskPresenter : IOutputPort<PutTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Task) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
