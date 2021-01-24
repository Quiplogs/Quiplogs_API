using Api.Core.Dto;
using Api.Core.Helpers;
using Quiplogs.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Assets.Data.Entities;
using Quiplogs.Assets.Domain.Entities;
using Quiplogs.Assets.Dto.Repositories.AssetUsage;
using Quiplogs.Assets.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Quiplogs.Infrastructure.Repositories
{
    public class AssetUsageRepository: IAssetUsageRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public AssetUsageRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListAssetUsageResponse> GetAll(Guid assetId, int pageNumber, int pageSize)
        {
            try
            {
                var modelList = await _context.AssetUsage.Where(
                    x => x.AssetId == assetId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToListAsync();

                List<AssetUsage> mappedModel = _mapper.Map<List<AssetUsage>>(modelList);
                return new ListAssetUsageResponse(mappedModel, true, null);
            }
            catch (SqlException ex)
            {
                return new ListAssetUsageResponse(null, false, new[] { new Error("", $"Error fetching Asset Usage. {ex.Message}") });
            }
        }

        public async Task<GetAssetUsageResponse> Get(Guid id)
        {
            try
            {
                var model =await _context.AssetUsage.FirstOrDefaultAsync(x => x.Id == id);

                var mappedModel = _mapper.Map<AssetUsage>(model);
                return new GetAssetUsageResponse(mappedModel, true, null);
            }
            catch (SqlException ex)
            {
                return new GetAssetUsageResponse(null, false, new[] { new Error("", $"Error fetching Asset Usage. {ex.Message}") });
            }
        }

        public async Task<PutAssetUsageResponse> Put(AssetUsage model)
        {
            try
            {
                var modelMapped = _mapper.Map<AssetUsageDto>(model);

                if (modelMapped.Id == null)
                {
                    _context.AssetUsage.Add(modelMapped);
                }
                else
                {
                    _context.AssetUsage.Update(modelMapped);
                }

                await _context.SaveChangesAsync();

                var mappedModel = _mapper.Map<AssetUsage>(modelMapped);
                return new PutAssetUsageResponse(mappedModel, true, null);
            }
            catch (SqlException ex)
            {
                return new PutAssetUsageResponse(null, false, new[] { new Error("", $"Error updating Asset Usage. {ex.Message}") });
            }
        }

        public async Task<RemoveAssetUsageResponse> Remove(Guid id)
        {
            try
            {
                var model = await _context.AssetUsage.FirstOrDefaultAsync(x => x.Id == id);

                _context.Remove(model);
                await _context.SaveChangesAsync();

                return new RemoveAssetUsageResponse(id.ToString(), true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveAssetUsageResponse(null, false, new[] { new Error("", $"Error removing Asset Usage. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(Guid assetId)
        {
            var _cacheKey = $"AssetUsage-total-{assetId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(assetId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(Guid assetId)
        {
            var _cacheKey = $"AssetUsage-total-{assetId}";
            var cachedTotal = _context.AssetUsage.Where(x => x.AssetId == assetId).Count();
            await _cache.SetAsnyc(_cacheKey, cachedTotal);
        }
    }
}
