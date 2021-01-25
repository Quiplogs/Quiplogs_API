using System.Collections.Generic;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.Location
{
    public class GetLocationResponse : ServiceResponseMessage
    {
        public Domain.Entities.Location Location { get; }
        public IEnumerable<Error> Errors { get; }

        public GetLocationResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetLocationResponse(Domain.Entities.Location location, bool success = false, string message = null) : base(success, message)
        {
            Location = location;
        }
    }
}
