using Api.Core.Dto;
using Api.Core.Helpers;
using Quiplogs.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Repositories.WorkOrder;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System;
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

        public async Task<ListWorkOrderResponse> List(Guid companyId, Guid locationId, Guid assetId, int pageNumber, int pageSize)
        {
            try
            {
                var WorkOrderList = _context.WorkOrders.Where(x =>
                    x.CompanyId == companyId
                    && (string.IsNullOrEmpty(locationId.ToString()) || x.LocationId == locationId)
                    && (string.IsNullOrEmpty(assetId.ToString()) || x.AssetId == assetId))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                var mappedWorkOrder = _mapper.Map<List<WorkOrderEntity>>(WorkOrderList);
                return new ListWorkOrderResponse(mappedWorkOrder, true, null);
            }
            catch (SqlException ex)
            {
                return new ListWorkOrderResponse(null, false, new[] { new Error("", $"Error fetching WorkOrder. {ex.Message}") });
            }
        }

        public int GetCurrentOpenWorkOrderCount(string companyId, string assetId)
        {
            //return _context.WorkOrders.Where(
            //    x => x.CompanyId == companyId
            //    && x.AssetId == assetId
            //    && x.).c

            return 0;
        }

        public int GetCurrentInProgressWorkOrderCount(string companyId, string assetId)
        {
            return 0;
        }

        public int GetCurrentCompletedWorkOrderCount(string companyId, string assetId)
        {
            return 0;
        }

        public async Task<GetWorkOrderResponse> Get(Guid id)
        {
            try
            {
                var WorkOrder = _context.WorkOrders.FirstOrDefault(x => x.Id == id);

                var mappedWorkOrder = _mapper.Map<WorkOrderEntity>(WorkOrder);
                return new GetWorkOrderResponse(mappedWorkOrder, true, null);
            }
            catch (SqlException ex)
            {
                return new GetWorkOrderResponse(null, false, new[] { new Error("", $"Error fetching WorkOrder. {ex.Message}") });
            }
        }

        public async Task<PutWorkOrderResponse> Put(WorkOrderEntity model)
        {
            try
            {
                var modelMapped = _mapper.Map<WorkOrderDto>(model);

                if (string.IsNullOrEmpty(modelMapped.Id.ToString()))
                {
                    _context.WorkOrders.Add(modelMapped);
                    await UpdateTotalItems(model.CompanyId, model.AssetId);
                }
                else
                {
                    _context.WorkOrders.Update(modelMapped);
                }

                await _context.SaveChangesAsync();

                var mappedWorkOrder = _mapper.Map<WorkOrderEntity>(modelMapped);
                return new PutWorkOrderResponse(mappedWorkOrder, true, null);
            }
            catch (SqlException ex)
            {
                return new PutWorkOrderResponse(null, false, new[] { new Error("", $"Error updating WorkOrder. {ex.Message}") });
            }
        }

        public async Task<RemoveWorkOrderResponse> Remove(Guid id)
        {
            try
            {
                var WorkOrder = _context.WorkOrders.FirstOrDefault(x => x.Id == id);

                _context.Remove(WorkOrder);
                await _context.SaveChangesAsync();

                return new RemoveWorkOrderResponse(id.ToString(), true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveWorkOrderResponse(null, false, new[] { new Error("", $"Error removing WorkOrder. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(Guid companyId, Guid assetId)
        {
            var _cacheKey = $"WorkOrder-total-{companyId}-{assetId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                cachedTotal = await UpdateTotalItems(companyId, assetId);
            }            

            return cachedTotal;
        }

        private async Task<int> UpdateTotalItems(Guid companyId, Guid assetId)
        {
            var _cacheKey = $"WorkOrder-total-{companyId}-{assetId}";
            await _cache.SetAsnyc(_cacheKey, 
                _context
                .WorkOrders
                .Where(x => x.CompanyId == companyId && x.AssetId == assetId)
                .Count());

            return await _cache.GetAsnyc<int>(_cacheKey);
        }
    }
}
