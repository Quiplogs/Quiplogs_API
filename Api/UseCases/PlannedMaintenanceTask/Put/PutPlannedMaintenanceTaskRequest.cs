namespace Api.UseCases.PlannedMaintenanceTask.Put
{
    public class PutPlannedMaintenanceTaskRequest
    {
        public string CompanyId { get; set; }
        public string PlannedMaintenanceId { get; set; }
        public string TaskId { get; set; }
        public decimal Quantity { get; set; }
    }
}
