using Api.Core.Dto;
using Api.Core.Dto.Responses;
using Api.Core.Domain.Entities;
using System.Collections.Generic;

namespace Quiplogs.Core.Dto
{
    public class BaseModelListResponse<T> : BaseResponse where T : BaseEntity
    {
        public List<T> Models { get; set; }

        public BaseModelListResponse(List<T> models, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Models = models;
        }
    }
}
