using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Interfaces
{
    public abstract class WorkOrderResponseMessage
    {
        public bool Success { get; }
        public string Message { get; }

        public WorkOrderResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
