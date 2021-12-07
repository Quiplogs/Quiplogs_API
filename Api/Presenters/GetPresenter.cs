using Api.Serialization;
using Quiplogs.Core.Dto.Responses.Generic;
using System.Net;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces;

namespace Api.Presenters
{
    public class GetPresenter<T> : IOutputPort<GetResponse<T>> where T : BaseEntity
    {
        public JsonContentResult ContentResult { get; }

        public GetPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetResponse<T> response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Model) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
