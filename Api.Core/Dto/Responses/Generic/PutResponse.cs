using System.Collections.Generic;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.Generic
{
    public class PutResponse<T> : ServiceResponseMessage
    {
        public T Model { get; }
        public IEnumerable<Error> Errors { get; }

        public PutResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutResponse(T model, bool success = false, string message = null) : base(success, message)
        {
            Model = model;
        }
    }
}
