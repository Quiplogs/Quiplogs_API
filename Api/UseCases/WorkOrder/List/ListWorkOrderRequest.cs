using System;

namespace Api.UseCases.WorkOrder.List
{
    public class ListWorkOrderRequest
    {
        public Guid CompanyId { get; set; }
        public Guid LocationId { get; set; }
        public Guid AssetId { get; set; }
        public int PageNumber { get; set; }
    }
}
