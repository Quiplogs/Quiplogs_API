using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Core.Dto.Repositories
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
