using Quiplogs.Core.Dto.Responses.Generic;
using System;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces;

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
