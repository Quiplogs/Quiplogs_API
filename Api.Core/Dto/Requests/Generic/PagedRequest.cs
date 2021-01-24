using System;
using Api.Core.Interfaces;
using Api.Core.Domain.Entities;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Dto.Requests.Generic
{
    public class PagedRequest<T> : IRequest<PagedResponse<T>> where T : BaseEntity
    {
        public Guid CompanyId { get; }
        public int PageNumber { get; }

        public PagedRequest(Guid companyId,  int pageNumber)
        {
            CompanyId = companyId;
            PageNumber = pageNumber;
        }
    }
}
