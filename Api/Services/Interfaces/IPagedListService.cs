﻿using System.Threading.Tasks;
using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;

namespace Api.Services.Interfaces
{
    public interface IPagedListService<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        Task<JsonContentResult> PagedList(PagedListRequest<T1> request);
    }
}
