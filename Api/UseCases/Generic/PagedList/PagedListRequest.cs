using System;

namespace Api.UseCases.Generic.PagedList
{
    public class PagedListRequest
    {
        public Guid CompanyId { get; set; }
        public int PageNumber { get; set; }
    }
}
