﻿using Api.Serialization;
using Quiplogs.Core.Dto.Responses.Generic;
using System.Net;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces;

namespace Api.Presenters
{
    public class ListPresenter<T> : IOutputPort<ListResponse<T>> where T : BaseEntity
    {
        public JsonContentResult ContentResult { get; }

        public ListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListResponse<T> response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.ModelList) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
