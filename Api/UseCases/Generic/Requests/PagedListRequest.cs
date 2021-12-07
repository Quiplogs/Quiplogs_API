using System;
using System.Collections.Generic;

namespace Api.UseCases.Generic.Requests
{
    public class PagedListRequest
    {
        public Guid? CompanyId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? ParentId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public Dictionary<string, string> FilterParameters { get; set; }
    }
}
