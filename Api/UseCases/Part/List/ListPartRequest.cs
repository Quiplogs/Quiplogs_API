using System;

namespace Api.UseCases.Part.List
{
    public class ListPartRequest
    {
        public Guid CompanyId { get; set; }
        public Guid LocationId { get; set; }
        public int PageNumber { get; set; }
        public string FilterName { get; set; }
    }
}
