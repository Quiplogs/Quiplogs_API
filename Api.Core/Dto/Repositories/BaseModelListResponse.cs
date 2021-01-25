using System.Collections.Generic;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Core.Dto.Repositories
{
    public class BaseModelListResponse<T> : BaseRepositoryResponse where T : BaseEntity
    {
        public List<T> Models { get; set; }

        public BaseModelListResponse(List<T> models, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Models = models;
        }
    }
}
