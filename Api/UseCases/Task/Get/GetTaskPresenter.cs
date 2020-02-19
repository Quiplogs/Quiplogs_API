using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

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
