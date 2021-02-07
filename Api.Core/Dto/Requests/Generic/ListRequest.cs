using Quiplogs.Core.Dto.Responses.Generic;
using System;
using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.Generic
{
    public class ListRequest<T> : IRequest<ListResponse<T>> where T : BaseEntity
    {
        public Guid? CompanyId { get; }
        public Guid? LocationId { get; }
        public Guid? ParentId { get; }
        public Dictionary<string, string> FilterParameters { get; set; }

        public ListRequest(Guid? companyId, Guid? locationId, Guid? parentId, Dictionary<string, string> filterParameters)
        {
            CompanyId = companyId;
            LocationId = locationId;
            FilterParameters = filterParameters;
            ParentId = parentId;
        }
    }
}
