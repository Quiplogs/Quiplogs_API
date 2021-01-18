using Api.Core;
using Api.Core.Dto;
using Api.Core.Helpers;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiplogs.Infrastructure.Repositories
{
    public class PlannedMaintenanceTaskRepository : IPlannedMaintenanceTaskRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public PlannedMaintenanceTaskRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListPlannedMaintenanceTaskResponse> List(string plannedMaintenanceId)
        {
            try
            {
                var modelList = 
                    _context.PlannedMaintenanceTasks
                    .Where(x => x.PlannedMaintenanceId == plannedMaintenanceId)
                    .Include(x => x.Task)
                    .ToList();

                var mappedList = _mapper.Map<List<PlannedMaintenanceTask>>(modelList);
                return new ListPlannedMaintenanceTaskResponse(mappedList, true, null);
            }
            catch (SqlException ex)
            {
                return new ListPlannedMaintenanceTaskResponse(null, false, new[] { new Error(GlobalVariables.error_list, $"Error fetching PlannedMaintenanceTask. {ex.Message}") });
            }
        }

        public async Task<PutPlannedMaintenanceTaskResponse> Put(PlannedMaintenanceTask PlannedMaintenanceTask)
        {
            try
            {
                var PlannedMaintenanceTaskMapped = _mapper.Map<PlannedMaintenanceTaskDto>(PlannedMaintenanceTask);

                if (string.IsNullOrEmpty(PlannedMaintenanceTaskMapped.Id))
                {
                    _context.PlannedMaintenanceTasks.Add(PlannedMaintenanceTaskMapped);
                }
                else
                {
                    _context.PlannedMaintenanceTasks.Update(PlannedMaintenanceTaskMapped);
                }

                await _context.SaveChangesAsync();

                var mappedPlannedMaintenanceTask = _mapper.Map<PlannedMaintenanceTask>(PlannedMaintenanceTaskMapped);
                return new PutPlannedMaintenanceTaskResponse(mappedPlannedMaintenanceTask, true, null);
            }
            catch (SqlException ex)
            {
                return new PutPlannedMaintenanceTaskResponse(null, false, new[] { new Error(GlobalVariables.error_plannedMaintenanceTaskFailure, $"Error updating PlannedMaintenanceTask. {ex.Message}") });
            }
        }

        public async Task<RemovePlannedMaintenanceTaskResponse> Remove(string id)
        {
            try
            {
                var PlannedMaintenanceTask = _context.PlannedMaintenanceTasks.FirstOrDefault(x => x.Id == id);

                _context.Remove(PlannedMaintenanceTask);
                await _context.SaveChangesAsync();

                return new RemovePlannedMaintenanceTaskResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemovePlannedMaintenanceTaskResponse(null, false, new[] { new Error(GlobalVariables.error_plannedMaintenanceTaskFailure, $"Error removing PlannedMaintenanceTask. {ex.Message}") });
            }
        }

        public int GetTotalRecords(string plannedMaintenanceId)
        {
            return _context.PlannedMaintenanceTasks.Where(x => x.PlannedMaintenanceId == plannedMaintenanceId).Count();
        }
    }
}
