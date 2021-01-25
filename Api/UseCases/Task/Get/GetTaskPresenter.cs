using Api.Presenters;
using Api.Serialization;
using Quiplogs.Inventory.Dto.Responses.Task;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.Task.Get
{
    public class GetTaskPresenter : IOutputPort<GetTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Task) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
