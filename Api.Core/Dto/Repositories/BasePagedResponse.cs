using System.Collections.Generic;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Core.Dto.Repositories
{
    public class BasePagedResponse<T> : BaseRepositoryResponse where T : BaseEntity
    {
        public PagedResult<T> PagedResult { get; set; }

        public BasePagedResponse(PagedResult<T> pagedResult, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            PagedResult = pagedResult;
        }
    }
}
