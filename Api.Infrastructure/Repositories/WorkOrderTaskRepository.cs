using Quiplogs.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Repositories.WorkOrderTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Helpers;

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

        public async Task<ListWorkOrderTaskResponse> List(Guid workOrderId, int pageNumber, int pageSize)
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
                return new ListWorkOrderTaskResponse(null, false, new[] { new Error("", $"Error fetching WorkOrderTask. {ex.Message}") });
            }
        }

        public async Task<PutWorkOrderTaskResponse> Put(WorkOrderTask WorkOrderTask)
        {
            try
            {
                var WorkOrderTaskMapped = _mapper.Map<WorkOrderTaskDto>(WorkOrderTask);

                if (string.IsNullOrEmpty(WorkOrderTaskMapped.Id.ToString()))
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
                return new PutWorkOrderTaskResponse(null, false, new[] { new Error("", $"Error updating WorkOrderTask. {ex.Message}") });
            }
        }

        public async Task<RemoveWorkOrderTaskResponse> Remove(Guid id)
        {
            try
            {
                var WorkOrderTask = _context.WorkOrderTasks.FirstOrDefault(x => x.Id == id);

                _context.Remove(WorkOrderTask);
                await _context.SaveChangesAsync();

                return new RemoveWorkOrderTaskResponse(id.ToString(), true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveWorkOrderTaskResponse(null, false, new[] { new Error("", $"Error removing WorkOrderTask. {ex.Message}") });
            }
        }

        public int GetTotalRecords(Guid workOrderId)
        {
            return _context.WorkOrderTasks.Where(x => x.WorkOrderId == workOrderId).Count();
        }
    }
}
