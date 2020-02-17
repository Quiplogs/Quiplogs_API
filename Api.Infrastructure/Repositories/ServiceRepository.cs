using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Repositories.Service;
using Api.Core.Helpers;
using Api.Core.Interfaces.Repositories;
using Api.Infrastructure.Data.Entities;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public ServiceRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListServiceResponse> List(string companyId, string locationId, int pageNumber, int pageSize)
        {
            try
            {
                var ServiceList = _context.Services.Where(x =>
                    x.CompanyId == companyId
                    && (string.IsNullOrEmpty(locationId) || x.LocationId == locationId))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                List<Service> mappedService = _mapper.Map<List<Service>>(ServiceList);
                return new ListServiceResponse(mappedService, true, null);
            }
            catch (SqlException ex)
            {
                return new ListServiceResponse(null, false, new[] { new Error(GlobalVariables.error_serviceFailure, $"Error fetching Service. {ex.Message}") });
            }
        }

        public async Task<GetServiceResponse> Get(string id)
        {
            try
            {
                var Service = _context.Services.FirstOrDefault(x => x.Id == id);

                Service mappedService = _mapper.Map<Service>(Service);
                return new GetServiceResponse(mappedService, true, null);
            }
            catch (SqlException ex)
            {
                return new GetServiceResponse(null, false, new[] { new Error(GlobalVariables.error_serviceFailure, $"Error fetching Service. {ex.Message}") });
            }
        }

        public async Task<PutServiceResponse> Put(Service Service)
        {
            try
            {
                var ServiceMapped = _mapper.Map<ServiceDto>(Service);

                if (string.IsNullOrEmpty(ServiceMapped.Id))
                {
                    _context.Services.Add(ServiceMapped);
                    await UpdateTotalItems(Service.CompanyId);
                }
                else
                {
                    _context.Services.Update(ServiceMapped);
                }

                await _context.SaveChangesAsync();

                Service mappedService = _mapper.Map<Service>(ServiceMapped);
                return new PutServiceResponse(mappedService, true, null);
            }
            catch (SqlException ex)
            {
                return new PutServiceResponse(null, false, new[] { new Error(GlobalVariables.error_serviceFailure, $"Error updating Service. {ex.Message}") });
            }
        }

        public async Task<RemoveServiceResponse> Remove(string id)
        {
            try
            {
                var Service = _context.Services.FirstOrDefault(x => x.Id == id);

                _context.Remove(Service);
                await _context.SaveChangesAsync();

                return new RemoveServiceResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveServiceResponse(null, false, new[] { new Error(GlobalVariables.error_serviceFailure, $"Error removing Service. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(string companyId)
        {
            var _cacheKey = $"Service-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(string companyId)
        {
            await _cache.SetAsnyc($"Service-total-{companyId}", _context.Services.Count());
        }
    }
}
