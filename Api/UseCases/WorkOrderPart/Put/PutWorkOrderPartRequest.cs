namespace Api.UseCases.WorkOrderPart.Put
{
    public class PutWorkOrderPartRequest
    {
        public string CompanyId { get; set; }
        public Quiplogs.WorkOrder.Domain.Entities.WorkOrderPart WorkOrderPart { get; set; }
    }
}
