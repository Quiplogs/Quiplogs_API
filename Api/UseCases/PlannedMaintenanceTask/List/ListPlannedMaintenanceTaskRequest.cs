namespace Api.UseCases.PlannedMaintenanceTask.List
{
    public class ListPlannedMaintenanceTaskRequest
    {
        public string PlannedMaintenanceId { get; set; }
        public int PageNumber { get; set; }
        public string CompanyId { get; set; }
    }
}
