using Api.Core;
using Api.Core.Dto;
using Api.Core.Helpers;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Assets.Data.Entities;
using Quiplogs.Assets.Domain.Entities;
using Quiplogs.Assets.Dto.Repositories.Asset;
using Quiplogs.Assets.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public AssetRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<FetchAssetResponse> GetAll(string companyId, string locationId, int pageNumber, int pageSize)
        {
            try
            {
                var modelList = _context.Asset.Where(
                    x => x.CompanyId == companyId
                    && (string.IsNullOrEmpty(locationId) || x.LocationId == locationId))
                    .Include(x => x.Location)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                var mappedList = _mapper.Map<List<Asset>>(modelList);
                return new FetchAssetResponse(mappedList, true, null);
            }
            catch (SqlException ex)
            {
                return new FetchAssetResponse(null, false, new[] { new Error(GlobalVariables.error_assetFailure, $"Error fetching Asset. {ex.Message}") });
            }
        }

        public async Task<GetAssetResponse> Get(string id)
        {
            try
            {
                var model = _context.Asset.FirstOrDefault(x => x.Id == id);

                var mappedModel = _mapper.Map<Asset>(model);
                return new GetAssetResponse(mappedModel, true, null);
            }
            catch (SqlException ex)
            {
                return new GetAssetResponse(null, false, new[] { new Error(GlobalVariables.error_assetFailure, $"Error fetching Asset. {ex.Message}") });
            }
        }

        public async Task<PutAssetResponse> Put(Asset model)
        {
            try
            {
                var modelMapped = _mapper.Map<AssetDto>(model);

                if (string.IsNullOrEmpty(modelMapped.Id))
                {
                    _context.Asset.Add(modelMapped);
                }
                else
                {
                    _context.Asset.Update(modelMapped);
                }
                
                await _context.SaveChangesAsync();

                var mappedModel = _mapper.Map<Asset>(modelMapped);
                return new PutAssetResponse(mappedModel, true, null);
            }
            catch (SqlException ex)
            {
                return new PutAssetResponse(null, false, new[] { new Error(GlobalVariables.error_assetFailure, $"Error updating Asset. {ex.Message}") });
            }
        }

        public async Task<RemoveAssetResponse> Remove(string id)
        {
            try
            {
                var model = _context.Asset.FirstOrDefault(x => x.Id == id);

                _context.Remove(model);
                await _context.SaveChangesAsync();

                return new RemoveAssetResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveAssetResponse(null, false, new[] { new Error(GlobalVariables.error_assetFailure, $"Error removing Asset. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(string companyId)
        {
            var _cacheKey = $"Asset-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(string companyId)
        {
            var _cacheKey = $"Asset-total-{companyId}";
            var cachedTotal = _context.Asset.Where(x => x.CompanyId == companyId).Count();
            await _cache.SetAsnyc(_cacheKey, cachedTotal);
        }
    }
}
