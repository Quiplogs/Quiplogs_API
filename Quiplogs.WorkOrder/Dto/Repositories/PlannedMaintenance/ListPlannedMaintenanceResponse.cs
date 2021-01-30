﻿using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance
{
    public class ListPlannedMaintenanceResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.PlannedMaintenance> PlannedMaintenances { get; set; }

        public ListPlannedMaintenanceResponse(List<Domain.Entities.PlannedMaintenance> plannedMaintenances, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PlannedMaintenances = plannedMaintenances;
        }
    }
}
