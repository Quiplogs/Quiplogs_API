using Api.Presenters;
using Api.Serialization;
using Quiplogs.Core.Dto.Responses.BlobStorage;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.BlobStorage.RemoveFile
{
    public class RemoveFilePresenter : IOutputPort<RemoveFileResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveFilePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveFileResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
