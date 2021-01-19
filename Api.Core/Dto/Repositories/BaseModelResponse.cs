using Api.Core.Domain.Entities;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories
{
    public class BaseModelResponse<T> : BaseRepositoryResponse where T : BaseEntity
    {
        public T Model { get; set; }

        public BaseModelResponse(T model, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Model = model;
        }
    }
}
