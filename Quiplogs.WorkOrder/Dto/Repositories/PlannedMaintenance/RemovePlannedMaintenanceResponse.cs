using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance
{
    public class RemovePlannedMaintenanceResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemovePlannedMaintenanceResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
