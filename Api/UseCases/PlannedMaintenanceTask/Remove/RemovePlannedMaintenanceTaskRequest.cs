using System;

namespace Api.UseCases.PlannedMaintenanceTask.Remove
{
    public class RemovePlannedMaintenanceTaskRequest
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }
    }
}
