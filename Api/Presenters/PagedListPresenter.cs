using Api.Serialization;
using Quiplogs.Core.Dto.Responses.Generic;
using System.Net;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces;

namespace Api.Presenters
{
    public class PagedListPresenter<T> : IOutputPort<PagedResponse<T>> where T : BaseEntity
    {
        public JsonContentResult ContentResult { get; }

        public PagedListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PagedResponse<T> response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
