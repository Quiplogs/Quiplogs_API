using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.Generic
{
    public class GetResponse<T> : ServiceResponseMessage where T : BaseEntity
    {
        public T Model { get; }
        public IEnumerable<Error> Errors { get; }

        public GetResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetResponse(T model, bool success = false, string message = null) : base(success, message)
        {
            Model = model;
        }
    }
}
