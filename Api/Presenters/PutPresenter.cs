using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using Api.Serialization;
using Quiplogs.Core.Dto.Responses.Generic;
using System.Net;

namespace Api.Presenters
{
    public class PutPresenter<T> : IOutputPort<PutResponse<T>> where T : BaseEntity
    {
        public JsonContentResult ContentResult { get; }

        public PutPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutResponse<T> response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Model) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
