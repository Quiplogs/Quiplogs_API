using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.Core.Dto.Responses
{
    public class BaseModelResponse<T> : BaseResponse where T : BaseEntity
    {
        public T Model { get; set; }

        public BaseModelResponse(T model, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Model = model;
        }
    }
}
