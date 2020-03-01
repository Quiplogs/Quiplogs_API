using Api.Core;
using Api.Core.Dto;
using Api.Core.Helpers;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiplogs.Infrastructure.Repositories
{
    public class PlannedMaintenanceRepository : IPlannedMaintenanceRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public PlannedMaintenanceRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListPlannedMaintenanceResponse> List(string companyId, string locationId, string assetId, int pageNumber, int pageSize)
        {
            try
            {
                var PlannedMaintenanceList = _context.PlannedMaintenances.Where(x =>
                    x.CompanyId == companyId
                    && (string.IsNullOrEmpty(locationId) || x.LocationId == locationId)
                    && (string.IsNullOrEmpty(assetId) || x.AssetId == assetId))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                var mappedPlannedMaintenance = _mapper.Map<List<PlannedMaintenanceEntity>>(PlannedMaintenanceList);
                return new ListPlannedMaintenanceResponse(mappedPlannedMaintenance, true, null);
            }
            catch (SqlException ex)
            {
                return new ListPlannedMaintenanceResponse(null, false, new[] { new Error(GlobalVariables.error_plannedMaintenanceFailure, $"Error fetching PlannedMaintenance. {ex.Message}") });
            }
        }

        public async Task<GetPlannedMaintenanceResponse> Get(string id)
        {
            try
            {
                var PlannedMaintenance = _context.PlannedMaintenances.FirstOrDefault(x => x.Id == id);

                var mappedPlannedMaintenance = _mapper.Map<PlannedMaintenanceEntity>(PlannedMaintenance);
                return new GetPlannedMaintenanceResponse(mappedPlannedMaintenance, true, null);
            }
            catch (SqlException ex)
            {
                return new GetPlannedMaintenanceResponse(null, false, new[] { new Error(GlobalVariables.error_plannedMaintenanceFailure, $"Error fetching PlannedMaintenance. {ex.Message}") });
            }
        }

        public async Task<PutPlannedMaintenanceResponse> Put(PlannedMaintenanceEntity PlannedMaintenance)
        {
            try
            {
                var PlannedMaintenanceMapped = _mapper.Map<PlannedMaintenanceDto>(PlannedMaintenance);

                if (string.IsNullOrEmpty(PlannedMaintenanceMapped.Id))
                {
                    _context.PlannedMaintenances.Add(PlannedMaintenanceMapped);
                    await UpdateTotalItems(PlannedMaintenance.CompanyId);
                }
                else
                {
                    _context.PlannedMaintenances.Update(PlannedMaintenanceMapped);
                }

                await _context.SaveChangesAsync();

                var mappedPlannedMaintenance = _mapper.Map<PlannedMaintenanceEntity>(PlannedMaintenanceMapped);
                return new PutPlannedMaintenanceResponse(mappedPlannedMaintenance, true, null);
            }
            catch (SqlException ex)
            {
                return new PutPlannedMaintenanceResponse(null, false, new[] { new Error(GlobalVariables.error_plannedMaintenanceFailure, $"Error updating PlannedMaintenance. {ex.Message}") });
            }
        }

        public async Task<RemovePlannedMaintenanceResponse> Remove(string id)
        {
            try
            {
                var PlannedMaintenance = _context.PlannedMaintenances.FirstOrDefault(x => x.Id == id);

                _context.Remove(PlannedMaintenance);
                await _context.SaveChangesAsync();

                return new RemovePlannedMaintenanceResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemovePlannedMaintenanceResponse(null, false, new[] { new Error(GlobalVariables.error_plannedMaintenanceFailure, $"Error removing PlannedMaintenance. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(string companyId)
        {
            var _cacheKey = $"PlannedMaintenance-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(string companyId)
        {
            await _cache.SetAsnyc($"PlannedMaintenance-total-{companyId}", _context.PlannedMaintenances.Count());
        }
    }
}
