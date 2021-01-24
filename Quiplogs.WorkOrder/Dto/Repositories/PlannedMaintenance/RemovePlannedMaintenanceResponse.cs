using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using System.Collections.Generic;

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
