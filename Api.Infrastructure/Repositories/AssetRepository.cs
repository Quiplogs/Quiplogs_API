using Api.Core;
using Api.Core.Dto;
using Api.Core.Helpers;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
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
                var AssetList = _context.Asset.Where(x =>
                    x.CompanyId == companyId
                    && (string.IsNullOrEmpty(locationId) || x.LocationId == locationId))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                List<Asset> mappedAsset = _mapper.Map<List<Asset>>(AssetList);
                return new FetchAssetResponse(mappedAsset, true, null);
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
                var Asset = _context.Asset.FirstOrDefault(x => x.Id == id);

                Asset mappedAsset = _mapper.Map<Asset>(Asset);
                return new GetAssetResponse(mappedAsset, true, null);
            }
            catch (SqlException ex)
            {
                return new GetAssetResponse(null, false, new[] { new Error(GlobalVariables.error_assetFailure, $"Error fetching Asset. {ex.Message}") });
            }
        }

        public async Task<PutAssetResponse> Put(Asset Asset)
        {
            try
            {
                var AssetMapped = _mapper.Map<AssetDto>(Asset);

                if (string.IsNullOrEmpty(AssetMapped.Id))
                {
                    _context.Asset.Add(AssetMapped);
                }
                else
                {
                    _context.Asset.Update(AssetMapped);
                }
                
                await _context.SaveChangesAsync();

                Asset mappedAsset = _mapper.Map<Asset>(AssetMapped);
                return new PutAssetResponse(mappedAsset, true, null);
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
                var Asset = _context.Asset.FirstOrDefault(x => x.Id == id);

                _context.Remove(Asset);
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
                cachedTotal = _context.Asset.Count();
                await _cache.SetAsnyc(_cacheKey, cachedTotal);
            }

            return cachedTotal;
        }

        private async Task UpdateAssetTotal(string companyId)
        {
            var _cacheKey = $"Asset-total-{companyId}";
            var cachedTotal = _context.Asset.Where(x => x.CompanyId == companyId).Count();
            await _cache.SetAsnyc(_cacheKey, cachedTotal);
        }
    }
}
