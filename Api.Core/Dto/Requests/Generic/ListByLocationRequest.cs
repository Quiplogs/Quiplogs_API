using System;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Core.Dto.Requests.Generic
{
    public class ListByLocationRequest<T> : ListRequest<T> where T : BaseEntity
    {
        public Guid? LocationId { get; }

        public ListByLocationRequest(Guid companyId, Guid? locationId) : base(companyId)
        {
            LocationId = locationId;
        }
    }
}
