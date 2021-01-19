using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Core.Domain.Entities;
using Api.Core.Dto.Repositories;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        Task<BaseModelListResponse<T1>> List(Expression<Func<T2, bool>> condition, Expression<Func<T2, T2>> include);

        Task<BasePagedResponse<T1>> PagedList(Expression<Func<T2, bool>> condition, Expression<Func<T2, T2>> include, int pageNumber, int pageSize);

        Task<BaseModelResponse<T1>> GetById(Guid id);

        Task<BaseModelResponse<T1>> Put(T1 model);

        Task Remove(Guid id);
    }
}
