using System;
using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;

namespace Api.UseCases.Generic.Requests
{
    public class PagedListRequest<T> where T : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? ParentId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public Dictionary<string, string> FilterParameters { get; set; }
    }
}
