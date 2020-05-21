﻿using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask
{
    public class RemovePlannedMaintenanceTaskResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemovePlannedMaintenanceTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemovePlannedMaintenanceTaskResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}