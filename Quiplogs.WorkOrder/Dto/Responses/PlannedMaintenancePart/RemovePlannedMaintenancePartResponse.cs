using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart
{
    public class RemovePlannedMaintenancePartResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemovePlannedMaintenancePartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemovePlannedMaintenancePartResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
