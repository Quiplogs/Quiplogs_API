using System;
using Api.Core;
using AutoMapper;
using System.Linq;
using Api.Core.Dto;
using Api.Core.Helpers;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Api.Core.Domain.Entities;
using Quiplogs.Core.Dto.Responses;
using Quiplogs.Core.Data.Entities;
using Api.Infrastructure.SqlContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using Quiplogs.Core.Dto;

namespace Quiplogs.Infrastructure.Repositories
{
    public class BaseRepository<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;
        private DbSet<T2> entities;

        public BaseRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
            entities = _context.Set<T2>();
        }

        public async Task<BaseModelListResponse<T1>> List(Expression<Func<T2, bool>> condition, Expression<Func<T2, T2>> include)
        {
            try
            {
                var modelList = new List<T2>();
                if (include == null)
                {
                    modelList = await entities.Include(include).Where(condition).ToListAsync();
                } else
                {
                    modelList = await entities.Where(condition).ToListAsync();
                }

                var mappedList = _mapper.Map<List<T1>>(modelList);
                return new BaseModelListResponse<T1>(mappedList, true, null);
            }
            catch (SqlException ex)
            {
                return new BaseModelListResponse<T1>(null, false, new[] { new Error(GlobalVariables.error_list, $"Error listing models-({typeof(T1).Name}). {ex.Message}") });
            }
        }

        public async Task<BaseModelResponse<T1>> GetById(Guid id)
        {
            try
            {
                var model = await entities.FirstOrDefaultAsync(x => x.Id == id);

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
                if (model.Id == null)
                {
                    entities.Add(modelMapped);
                }
                else
                {
                    entities.Update(modelMapped);
                }

                await _context.SaveChangesAsync();
                await UpdateTotalItems(modelMapped.CompanyId);

                var mappedUpdatedModel = _mapper.Map<T1>(modelMapped);
                return new BaseModelResponse<T1>(mappedUpdatedModel, true, null);
            }
            catch (SqlException ex)
            {
                return new BaseModelResponse<T1>(null, false, new[] { new Error(GlobalVariables.error_upsert, $"Error updating model-({typeof(T1).Name}). {ex.Message}") });
            }
        }

        public async Task Remove(Guid id)
        {
            var model = await entities.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTotalRecords(Guid companyId)
        {
            var _cacheKey = $"{typeof(T1).Name}-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(Guid companyId)
        {
            var _cacheKey = $"{typeof(T1).Name}-total-{companyId}";
            var cachedTotal = entities.Where(x => x.CompanyId == companyId).Count();
            await _cache.SetAsnyc(_cacheKey, cachedTotal);
        }
    }
}
