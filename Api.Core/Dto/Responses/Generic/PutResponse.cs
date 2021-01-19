using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

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
