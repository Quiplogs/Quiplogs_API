using System;

namespace Api.UseCases.WorkOrderPart.List
{
    public class ListWorkOrderPartRequest
    {
        public Guid WordOrderId { get; set; }
        public Guid CompanyId { get; set; }
        public int PageNumber { get; set; }
    }
}
