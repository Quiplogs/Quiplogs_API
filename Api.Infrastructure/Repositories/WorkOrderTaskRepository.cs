using Api.Core;
using Api.Core.Dto;
using Api.Core.Helpers;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Repositories.WorkOrderTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiplogs.Infrastructure.Repositories
{
    public class WorkOrderTaskRepository : IWorkOrderTaskRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public WorkOrderTaskRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListWorkOrderTaskResponse> List(string workOrderId, int pageNumber, int pageSize)
        {
            try
            {
                var WorkOrderTaskList = _context.WorkOrderTasks.Where(x =>
                    x.WorkOrderId == workOrderId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                var mappedWorkOrderTask = _mapper.Map<List<WorkOrderTask>>(WorkOrderTaskList);
                return new ListWorkOrderTaskResponse(mappedWorkOrderTask, true, null);
            }
            catch (SqlException ex)
            {
                return new ListWorkOrderTaskResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderTaskFailure, $"Error fetching WorkOrderTask. {ex.Message}") });
            }
        }

        public async Task<PutWorkOrderTaskResponse> Put(WorkOrderTask WorkOrderTask)
        {
            try
            {
                var WorkOrderTaskMapped = _mapper.Map<WorkOrderTaskDto>(WorkOrderTask);

                if (string.IsNullOrEmpty(WorkOrderTaskMapped.Id))
                {
                    _context.WorkOrderTasks.Add(WorkOrderTaskMapped);
                }
                else
                {
                    _context.WorkOrderTasks.Update(WorkOrderTaskMapped);
                }

                await _context.SaveChangesAsync();

                var mappedWorkOrderTask = _mapper.Map<WorkOrderTask>(WorkOrderTaskMapped);
                return new PutWorkOrderTaskResponse(mappedWorkOrderTask, true, null);
            }
            catch (SqlException ex)
            {
                return new PutWorkOrderTaskResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderTaskFailure, $"Error updating WorkOrderTask. {ex.Message}") });
            }
        }

        public async Task<RemoveWorkOrderTaskResponse> Remove(string id)
        {
            try
            {
                var WorkOrderTask = _context.WorkOrderTasks.FirstOrDefault(x => x.Id == id);

                _context.Remove(WorkOrderTask);
                await _context.SaveChangesAsync();

                return new RemoveWorkOrderTaskResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveWorkOrderTaskResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderTaskFailure, $"Error removing WorkOrderTask. {ex.Message}") });
            }
        }

        public int GetTotalRecords(string workOrderId)
        {
            return _context.WorkOrderTasks.Where(x => x.WorkOrderId == workOrderId).Count();
        }
    }
}
