using System;

namespace Api.UseCases.PlannedMaintenancePart.Remove
{
    public class RemovePlannedMaintenancePartRequest
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }
    }
}
