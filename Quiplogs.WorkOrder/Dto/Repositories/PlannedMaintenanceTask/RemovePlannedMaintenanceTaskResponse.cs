using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenanceTask
{
    public class RemovePlannedMaintenanceTaskResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemovePlannedMaintenanceTaskResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
