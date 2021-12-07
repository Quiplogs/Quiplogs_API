using System.Collections.Generic;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.BlobStorage
{
    public class RemoveFileResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveFileResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveFileResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
