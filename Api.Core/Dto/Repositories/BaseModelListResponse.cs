using Api.Core.Domain.Entities;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories
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
