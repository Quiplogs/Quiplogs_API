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
using System;
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

        public async Task<FetchAssetResponse> GetAll(Guid companyId, Guid? locationId, int pageNumber, int pageSize)
        {
            try
            {
                var modelList = _context.Asset.Where(
                    x => x.CompanyId == companyId
                    && (!locationId.HasValue|| x.LocationId == locationId.Value))
                    .Include(x => x.Location)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                var mappedList = _mapper.Map<List<Asset>>(modelList);
                return new FetchAssetResponse(mappedList, true, null);
            }
            catch (SqlException ex)
            {
                return new FetchAssetResponse(null, false, new[] { new Error("", $"Error fetching Asset. {ex.Message}") });
            }
        }

        public async Task<GetAssetResponse> Get(Guid id)
        {
            try
            {
                var model = _context.Asset.FirstOrDefault(x => x.Id == id);

                var mappedModel = _mapper.Map<Asset>(model);
                return new GetAssetResponse(mappedModel, true, null);
            }
            catch (SqlException ex)
            {
                return new GetAssetResponse(null, false, new[] { new Error("", $"Error fetching Asset. {ex.Message}") });
            }
        }

        public async Task<PutAssetResponse> Put(Asset model)
        {
            try
            {
                var modelMapped = _mapper.Map<AssetDto>(model);

                if (modelMapped.Id == null)
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
                return new PutAssetResponse(null, false, new[] { new Error("", $"Error updating Asset. {ex.Message}") });
            }
        }

        public async Task<RemoveAssetResponse> Remove(Guid id)
        {
            try
            {
                var model = _context.Asset.FirstOrDefault(x => x.Id == id);

                _context.Remove(model);
                await _context.SaveChangesAsync();

                return new RemoveAssetResponse(id.ToString(), true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveAssetResponse(null, false, new[] { new Error("", $"Error removing Asset. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(Guid companyId)
        {
            var _cacheKey = $"Asset-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(Guid companyId)
        {
            var _cacheKey = $"Asset-total-{companyId}";
            var cachedTotal = _context.Asset.Where(x => x.CompanyId == companyId).Count();
            await _cache.SetAsnyc(_cacheKey, cachedTotal);
        }
    }
}
