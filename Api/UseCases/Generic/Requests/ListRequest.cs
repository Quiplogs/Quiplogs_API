using System;

namespace Api.UseCases.Generic.Requests
{
    public class ListRequest
    {
        public Guid CompanyId { get; set; }
        public int PageNumber { get; set; }
    }
}
