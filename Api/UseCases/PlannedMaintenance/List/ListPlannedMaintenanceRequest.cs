namespace Api.UseCases.PlannedMaintenance.List
{
    public class ListPlannedMaintenanceRequest
    {
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public string AssetId { get; set; }
        public int PageNumber { get; set; }
    }
}
