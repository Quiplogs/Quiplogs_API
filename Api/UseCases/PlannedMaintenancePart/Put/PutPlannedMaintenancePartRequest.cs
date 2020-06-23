namespace Api.UseCases.PlannedMaintenancePart.Put
{
    public class PutPlannedMaintenancePartRequest
    {
        public string CompanyId { get; set; }
        public string PlannedMaintenanceId { get; set; }
        public string PartId { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
    }
}
