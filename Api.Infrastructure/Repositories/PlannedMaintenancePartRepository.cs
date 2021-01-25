using Quiplogs.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Helpers;

namespace Quiplogs.Infrastructure.Repositories
{
    public class PlannedMaintenancePartRepository : IPlannedMaintenancePartRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public PlannedMaintenancePartRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListPlannedMaintenancePartResponse> List(Guid plannedMaintenanceId)
        {
            try
            {
                var modelList =  _context.PlannedMaintenanceParts
                                .Include(y => y.Part)
                                .Where(x => x.PlannedMaintenanceId == plannedMaintenanceId)
                                .ToList();

                var mappedPlannedMaintenancePart = _mapper.Map<List<PlannedMaintenancePart>>(modelList);
                return new ListPlannedMaintenancePartResponse(mappedPlannedMaintenancePart, true, null);
            }
            catch (SqlException ex)
            {
                return new ListPlannedMaintenancePartResponse(null, false, new[] { new Error("", $"Error fetching PlannedMaintenancePart. {ex.Message}") });
            }
        }

        public async Task<PutPlannedMaintenancePartResponse> Put(PlannedMaintenancePart PlannedMaintenancePart)
        {
            try
            {
                var PlannedMaintenancePartMapped = _mapper.Map<PlannedMaintenancePartDto>(PlannedMaintenancePart);

                if (string.IsNullOrEmpty(PlannedMaintenancePartMapped.Id.ToString()))
                {
                    _context.PlannedMaintenanceParts.Add(PlannedMaintenancePartMapped);
                }
                else
                {
                    _context.PlannedMaintenanceParts.Update(PlannedMaintenancePartMapped);
                }

                await _context.SaveChangesAsync();

                var mappedPlannedMaintenancePart = _mapper.Map<PlannedMaintenancePart>(PlannedMaintenancePartMapped);
                return new PutPlannedMaintenancePartResponse(mappedPlannedMaintenancePart, true, null);
            }
            catch (SqlException ex)
            {
                return new PutPlannedMaintenancePartResponse(null, false, new[] { new Error("", $"Error updating PlannedMaintenancePart. {ex.Message}") });
            }
        }

        public async Task<RemovePlannedMaintenancePartResponse> Remove(Guid id)
        {
            try
            {
                var PlannedMaintenancePart = _context.PlannedMaintenanceParts.FirstOrDefault(x => x.Id == id);

                _context.Remove(PlannedMaintenancePart);
                await _context.SaveChangesAsync();

                return new RemovePlannedMaintenancePartResponse(id.ToString(), true, null);
            }
            catch (SqlException ex)
            {
                return new RemovePlannedMaintenancePartResponse(null, false, new[] { new Error("", $"Error removing PlannedMaintenancePart. {ex.Message}") });
            }
        }

        public int GetTotalRecords(Guid plannedMaintenanceId)
        {
            return _context.PlannedMaintenanceParts.Where(x => x.PlannedMaintenanceId == plannedMaintenanceId).Count();
        }
    }
}
