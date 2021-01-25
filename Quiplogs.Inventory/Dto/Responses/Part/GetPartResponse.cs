using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Inventory.Dto.Responses.Part
{
    public class GetPartResponse : ServiceResponseMessage
    {
        public Domain.Entities.Part Part { get; }
        public IEnumerable<Error> Errors { get; }

        public GetPartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetPartResponse(Domain.Entities.Part part, bool success = false, string message = null) : base(success, message)
        {
            Part = part;
        }
    }
}
