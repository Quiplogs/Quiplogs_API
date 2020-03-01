namespace Api.UseCases.PlannedMaintenancePart.List
{
    public class ListPlannedMaintenancePartRequest
    {
        public string PlannedMaintenanceId { get; set; }
        public int PageNumber { get; set; }
    }
}
