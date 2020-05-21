namespace Api.UseCases.PlannedMaintenance.Put
{
    public class PutPlannedMaintenanceRequest
    {
        public string AssetId { get; set; }

        public string CompanyId { get; set; }

        public decimal Cycles { get; set; }

        public bool IsRecurring { get; set; }

        public int UoM { get; set; }
    }
}
