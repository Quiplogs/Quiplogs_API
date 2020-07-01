namespace Api.UseCases.WorkOrder.Put
{
    public class PutWorkOrderRequest
    {
        public string CompanyId { get; set; }
        public Quiplogs.WorkOrder.Domain.Entities.WorkOrderEntity WorkOrder { get; set; }
    }
}
