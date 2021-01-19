using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Responses.Generic;
using System;

namespace Quiplogs.Core.Dto.Requests.Generic
{
    public class ListRequest<T> : IRequest<ListResponse<T>> where T : BaseEntity
    {
        public Guid CompanyId { get; }

        public ListRequest(Guid companyId)
        {
            CompanyId = companyId;
        }
    }
}
