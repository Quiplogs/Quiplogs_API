using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quiplogs.Core;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;
using Quiplogs.Core.Helpers;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Infrastructure.Helper;
using Quiplogs.Infrastructure.SqlContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quiplogs.Infrastructure.Repositories
{
    public class BaseRepository<T1, T2> : IBaseRepository<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private readonly ICaching _cache;
        private readonly DbSet<T2> _entities;

        public BaseRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
            _entities = _context.Set<T2>();
        }

        public async Task<BaseModelListResponse<T1>> List(Guid companyId, Expression<Func<T2, bool>> predicate = null, Dictionary<string, string> filterParameters = null, Func<IQueryable<T2>, IIncludableQueryable<T2, object>> including = null)
        {
            try
            {
                var modelList = await _entities
                                        .AsQueryable()
                                        .CustomWhere(predicate)
                                        .CustomInclude(including)
                                        .FilterByString(filterParameters)
                                        .Where(x => x.CompanyId == companyId)
                                        .ToListAsync();

                var mappedList = _mapper.Map<List<T1>>(modelList);
                return new BaseModelListResponse<T1>(mappedList, true, null);
            }
            catch (SqlException ex)
            {
                return new BaseModelListResponse<T1>(null, false, new[] { new Error(GlobalVariables.error_list, $"Error listing models-({typeof(T1).Name}). {ex.Message}") });
            }
        }

        public async Task<BasePagedResponse<T1>> PagedList(Guid companyId, int pageNumber, int pageSize, Dictionary<string, string> filterParameters, Expression<Func<T2, bool>> predicate, Func<IQueryable<T2>, IIncludableQueryable<T2, object>> including = null)
        {
            try
            {
                var modelList = await _entities
                                        .AsQueryable()
                                        .CustomWhere(predicate)
                                        .CustomInclude(including)
                                        .FilterByString(filterParameters)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .Where(x => x.CompanyId == companyId)
                                        .ToListAsync();

                var mappedList = _mapper.Map<List<T1>>(modelList);
                var total = await GetTotalRecords(companyId, predicate, filterParameters);
                var pagedResult = new PagedResult<T1>(mappedList, total, pageNumber, pageSize);
                
                return new BasePagedResponse<T1>(pagedResult, true, null);
            }
            catch (SqlException ex)
            {
                return new BasePagedResponse<T1>(null, false, new[] { new Error(GlobalVariables.error_list, $"Error listing models-({typeof(T1).Name}). {ex.Message}") });
            }
        }

        public async Task<BaseModelResponse<T1>> GetById(Guid id, Func<IQueryable<T2>, IIncludableQueryable<T2, object>> including = null)
        {
            try
            {
                var model = await _entities.AsNoTracking()
                    .Where(x => x.Id == id)
                    .CustomInclude(including)
                    .FirstOrDefaultAsync();

                var mappedModel = _mapper.Map<T1>(model);
                return new BaseModelResponse<T1>(mappedModel, true, null);
            }
            catch (SqlException ex)
            {
                return new BaseModelResponse<T1>(null, false, new[] { new Error(GlobalVariables.error_getById, $"Error getting model-({typeof(T1).Name}) by id. {ex.Message}") });
            }
        }

        public async Task<BaseModelResponse<T1>> Put(T1 model)
        {
            try
            {
                var modelMapped = _mapper.Map<T2>(model);
                if (model.Id == Guid.Empty)
                {
                    await _entities.AddAsync(modelMapped);
                }
                else
                {
                    var entry = _entities.First(e => e.Id == model.Id);
                    _context.Entry(entry).CurrentValues.SetValues(model);
                }
                
                await _context.SaveChangesAsync();
                await UpdateTotalItems(modelMapped.CompanyId);

                var mappedUpdatedModel = _mapper.Map<T1>(modelMapped);
                return new BaseModelResponse<T1>(mappedUpdatedModel, true, null);
            }
            catch (Exception ex)
            {
                return new BaseModelResponse<T1>(null, false, new[] { new Error(GlobalVariables.error_upsert, $"Error updating model-({typeof(T1).Name}). {ex.Message}") });
            }
        }

        public async Task Remove(Guid id)
        {
            var model = await _entities.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        private async Task<int> GetTotalRecords(Guid companyId, Expression<Func<T2, bool>> predicate = null, Dictionary<string, string> filterParameters = null)
        {
            var cacheKey = $"{typeof(T1).Name}-total-{companyId}";
            var total = await _cache.GetAsnyc<int>(cacheKey);

            if (total == 0)
            {
                await UpdateTotalItems(companyId);
            }

            if (predicate != null || filterParameters != null)
            {
                total = _entities.Where(predicate).FilterByString(filterParameters).Count();
            }

            return total;
        }

        private async Task UpdateTotalItems(Guid companyId)
        {
            var cacheKey = $"{typeof(T1).Name}-total-{companyId}";
            var cachedTotal = _entities.Where(x => x.CompanyId == companyId).Count();
            await _cache.SetAsnyc(cacheKey, cachedTotal);
        }
    }
}
