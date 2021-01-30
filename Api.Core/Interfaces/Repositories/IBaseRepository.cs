using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        Task<BaseModelListResponse<T1>> List();

        Task<BasePagedResponse<T1>> PagedList(IQueryable<T2> baseQuery, Guid companyId, int pageNumber, int pageSize);

        Task<BaseModelResponse<T1>> GetById(Guid id);

        Task<BaseModelResponse<T1>> Put(T1 model);

        Task Remove(Guid id);

        IQueryable<T2> BaseQuery(Expression<Func<T2, bool>> predicate = null, Expression<Func<T2, object>> include = null);

        IQueryable<T2> BaseQueryFilter(
            Dictionary<string, string> filterParameters,
            Expression<Func<T2, bool>> predicate = null,
            Expression<Func<T2, object>> include = null);
    }
}
