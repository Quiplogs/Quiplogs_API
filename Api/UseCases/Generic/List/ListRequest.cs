using System;

namespace Api.UseCases.Generic.List
{
    public class ListRequest
    {
        public Guid CompanyId { get; set; }
        public int PageNumber { get; set; }
    }
}
