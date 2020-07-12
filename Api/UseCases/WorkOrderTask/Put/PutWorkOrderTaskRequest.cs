namespace Api.UseCases.WorkOrderTask.Put
{
    public class PutWorkOrderTaskRequest
    {
        public string CompanyId { get; set; }
        public Quiplogs.WorkOrder.Domain.Entities.WorkOrderTask WorkOrderTask { get; set; }
    }
}
