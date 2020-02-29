using Api.Core;
using Api.Core.Dto;
using Api.Core.Helpers;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Repositories.WorkOrderPart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiplogs.Infrastructure.Repositories
{
    public class WorkOrderPartRepository : IWorkOrderPartRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public WorkOrderPartRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListWorkOrderPartResponse> List(string workOrderId, int pageNumber, int pageSize)
        {
            try
            {
                var WorkOrderPartList = _context.WorkOrderParts.Where(x =>
                    x.WorkOrderId == workOrderId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                var mappedWorkOrderPart = _mapper.Map<List<WorkOrderPart>>(WorkOrderPartList);
                return new ListWorkOrderPartResponse(mappedWorkOrderPart, true, null);
            }
            catch (SqlException ex)
            {
                return new ListWorkOrderPartResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderPartFailure, $"Error fetching WorkOrderPart. {ex.Message}") });
            }
        }

        public async Task<PutWorkOrderPartResponse> Put(WorkOrderPart WorkOrderPart)
        {
            try
            {
                var WorkOrderPartMapped = _mapper.Map<WorkOrderPartDto>(WorkOrderPart);

                if (string.IsNullOrEmpty(WorkOrderPartMapped.Id))
                {
                    _context.WorkOrderParts.Add(WorkOrderPartMapped);
                }
                else
                {
                    _context.WorkOrderParts.Update(WorkOrderPartMapped);
                }

                await _context.SaveChangesAsync();

                var mappedWorkOrderPart = _mapper.Map<WorkOrderPart>(WorkOrderPartMapped);
                return new PutWorkOrderPartResponse(mappedWorkOrderPart, true, null);
            }
            catch (SqlException ex)
            {
                return new PutWorkOrderPartResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderPartFailure, $"Error updating WorkOrderPart. {ex.Message}") });
            }
        }

        public async Task<RemoveWorkOrderPartResponse> Remove(string id)
        {
            try
            {
                var WorkOrderPart = _context.WorkOrderParts.FirstOrDefault(x => x.Id == id);

                _context.Remove(WorkOrderPart);
                await _context.SaveChangesAsync();

                return new RemoveWorkOrderPartResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveWorkOrderPartResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderPartFailure, $"Error removing WorkOrderPart. {ex.Message}") });
            }
        }

        public int GetTotalRecords(string workOrderId)
        {
            return _context.WorkOrderParts.Where(x => x.WorkOrderId == workOrderId).Count();
        }
    }
}
