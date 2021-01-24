using Api.Core.Interfaces;
using Api.Serialization;
using Quiplogs.Core.Dto.Responses.Generic;
using System.Net;

namespace Api.Presenters
{
    public class RemovePresenter : IOutputPort<RemoveResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemovePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
