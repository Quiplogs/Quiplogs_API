using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenanceTask
{
    public class PutPlannedMaintenanceTaskResponse : BaseResponse
    {
        public string UpdateMessage { get; set; }

        public PutPlannedMaintenanceTaskResponse(string updateMessage, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            UpdateMessage = updateMessage;
        }
    }
}
