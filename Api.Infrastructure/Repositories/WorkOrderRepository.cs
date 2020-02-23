using Api.Core;
using Api.Core.Dto;
using Api.Core.Helpers;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Quiplogs.Infrastructure.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Repositories.WorkOrder;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class WorkOrderRepository : IWorkOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public WorkOrderRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListWorkOrderResponse> List(string companyId, string locationId, int pageNumber, int pageSize)
        {
            try
            {
                var WorkOrderList = _context.WorkOrders.Where(x =>
                    x.CompanyId == companyId
                    && (string.IsNullOrEmpty(locationId) || x.LocationId == locationId))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                var mappedWorkOrder = _mapper.Map<List<WorkOrder>>(WorkOrderList);
                return new ListWorkOrderResponse(mappedWorkOrder, true, null);
            }
            catch (SqlException ex)
            {
                return new ListWorkOrderResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderFailure, $"Error fetching WorkOrder. {ex.Message}") });
            }
        }

        public async Task<GetWorkOrderResponse> Get(string id)
        {
            try
            {
                var WorkOrder = _context.WorkOrders.FirstOrDefault(x => x.Id == id);

                WorkOrder mappedWorkOrder = _mapper.Map<WorkOrder>(WorkOrder);
                return new GetWorkOrderResponse(mappedWorkOrder, true, null);
            }
            catch (SqlException ex)
            {
                return new GetWorkOrderResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderFailure, $"Error fetching WorkOrder. {ex.Message}") });
            }
        }

        public async Task<PutWorkOrderResponse> Put(WorkOrder WorkOrder)
        {
            try
            {
                var WorkOrderMapped = _mapper.Map<WorkOrderDto>(WorkOrder);

                if (string.IsNullOrEmpty(WorkOrderMapped.Id))
                {
                    _context.WorkOrders.Add(WorkOrderMapped);
                    await UpdateTotalItems(WorkOrder.CompanyId);
                }
                else
                {
                    _context.WorkOrders.Update(WorkOrderMapped);
                }

                await _context.SaveChangesAsync();

                WorkOrder mappedWorkOrder = _mapper.Map<WorkOrder>(WorkOrderMapped);
                return new PutWorkOrderResponse(mappedWorkOrder, true, null);
            }
            catch (SqlException ex)
            {
                return new PutWorkOrderResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderFailure, $"Error updating WorkOrder. {ex.Message}") });
            }
        }

        public async Task<RemoveWorkOrderResponse> Remove(string id)
        {
            try
            {
                var WorkOrder = _context.WorkOrders.FirstOrDefault(x => x.Id == id);

                _context.Remove(WorkOrder);
                await _context.SaveChangesAsync();

                return new RemoveWorkOrderResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveWorkOrderResponse(null, false, new[] { new Error(GlobalVariables.error_workOrderFailure, $"Error removing WorkOrder. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(string companyId)
        {
            var _cacheKey = $"WorkOrder-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(string companyId)
        {
            await _cache.SetAsnyc($"WorkOrder-total-{companyId}", _context.WorkOrders.Count());
        }
    }
}
