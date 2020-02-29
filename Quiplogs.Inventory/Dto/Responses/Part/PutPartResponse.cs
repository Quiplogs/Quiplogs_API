using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Responses.Part
{
    public class PutPartResponse : ServiceResponseMessage
    {
        public Domain.Entities.Part Part { get; }
        public IEnumerable<Error> Errors { get; }

        public PutPartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutPartResponse(Domain.Entities.Part part, bool success = false, string message = null) : base(success, message)
        {
            Part = part;
        }
    }
}
