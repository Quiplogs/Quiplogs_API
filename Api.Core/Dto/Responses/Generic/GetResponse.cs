using Api.Core.Dto;
using Api.Core.Interfaces;
using Api.Core.Domain.Entities;
using System.Collections.Generic;

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
