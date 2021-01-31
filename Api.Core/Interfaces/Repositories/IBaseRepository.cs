﻿using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quiplogs.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        Task<BaseModelListResponse<T1>> List(Dictionary<string, string> filterParameters, Expression<Func<T2, bool>> predicate = null, List<Expression<Func<T2, object>>> includes = null);

        Task<BasePagedResponse<T1>> PagedList(Guid companyId, int pageNumber, int pageSize, Dictionary<string, string> filterParameters, Expression<Func<T2, bool>> predicate = null, List<Expression<Func<T2, object>>> includes = null);

        Task<BaseModelResponse<T1>> GetById(Guid id);

        Task<BaseModelResponse<T1>> Put(T1 model);

        Task Remove(Guid id);
    }
}
