using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Responses.Task
{
    public class PutTaskResponse : ServiceResponseMessage
    {
        public Domain.Entities.TaskEntity Task { get; }
        public IEnumerable<Error> Errors { get; }

        public PutTaskResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutTaskResponse(Domain.Entities.TaskEntity task, bool success = false, string message = null) : base(success, message)
        {
            Task = task;
        }
    }
}
