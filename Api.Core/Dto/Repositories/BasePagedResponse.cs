using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using System.Collections.Generic;

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
