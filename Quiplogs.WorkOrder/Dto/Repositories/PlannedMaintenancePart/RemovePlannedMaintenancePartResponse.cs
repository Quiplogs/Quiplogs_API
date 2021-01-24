using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenancePart
{
    public class RemovePlannedMaintenancePartResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemovePlannedMaintenancePartResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
