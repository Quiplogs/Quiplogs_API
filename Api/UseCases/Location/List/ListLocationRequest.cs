using System;

namespace Api.UseCases.Location.List
{
    public class ListLocationRequest
    {
        public Guid CompanyId { get; set; }
        public int PageNumber { get; set; }
        public string FilterName { get; set; }
    }
}
