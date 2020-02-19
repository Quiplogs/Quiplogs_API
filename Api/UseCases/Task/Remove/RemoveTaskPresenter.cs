using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Task.Remove
{
    public class RemoveTaskPresenter : IOutputPort<RemoveTaskResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveTaskPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveTaskResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
