using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Repositories.Equipment;
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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public EquipmentRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<FetchEquipmentResponse> GetAll(string companyId, string locationId, int pageNumber, int pageSize)
        {
            try
            {
                var equipmentList = _context.Equipment.Where(x =>
                    x.CompanyId == companyId
                    && (string.IsNullOrEmpty(locationId) || x.LocationId == locationId))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                List<Equipment> mappedEquipment = _mapper.Map<List<Equipment>>(equipmentList);
                return new FetchEquipmentResponse(mappedEquipment, true, null);
            }
            catch (SqlException ex)
            {
                return new FetchEquipmentResponse(null, false, new[] { new Error(GlobalVariables.error_equipmentFailure, $"Error fetching Equipment. {ex.Message}") });
            }
        }

        public async Task<GetEquipmentResponse> Get(string id)
        {
            try
            {
                var equipment = _context.Equipment.FirstOrDefault(x => x.Id == id);

                Equipment mappedEquipment = _mapper.Map<Equipment>(equipment);
                return new GetEquipmentResponse(mappedEquipment, true, null);
            }
            catch (SqlException ex)
            {
                return new GetEquipmentResponse(null, false, new[] { new Error(GlobalVariables.error_equipmentFailure, $"Error fetching Equipment. {ex.Message}") });
            }
        }

        public async Task<UpdateEquipmentResponse> Put(Equipment equipment)
        {
            try
            {
                var equipmentMapped = _mapper.Map<EquipmentDto>(equipment);

                if (string.IsNullOrEmpty(equipmentMapped.Id))
                {
                    _context.Equipment.Add(equipmentMapped);
                }
                else
                {
                    _context.Equipment.Update(equipmentMapped);
                }
                
                await _context.SaveChangesAsync();

                Equipment mappedEquipment = _mapper.Map<Equipment>(equipmentMapped);
                return new UpdateEquipmentResponse(mappedEquipment, true, null);
            }
            catch (SqlException ex)
            {
                return new UpdateEquipmentResponse(null, false, new[] { new Error(GlobalVariables.error_equipmentFailure, $"Error updating Equipment. {ex.Message}") });
            }
        }

        public async Task<RemoveEquipmentResponse> Remove(string id)
        {
            try
            {
                var equipment = _context.Equipment.FirstOrDefault(x => x.Id == id);

                _context.Remove(equipment);
                await _context.SaveChangesAsync();

                return new RemoveEquipmentResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveEquipmentResponse(null, false, new[] { new Error(GlobalVariables.error_equipmentFailure, $"Error removing Equipment. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(string companyId)
        {
            var _cacheKey = $"Equipment-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                cachedTotal = _context.Equipment.Count();
                await _cache.SetAsnyc(_cacheKey, cachedTotal);
            }

            return cachedTotal;
        }

        private async Task UpdateEquipmentTotal(string companyId)
        {
            var _cacheKey = $"Equipment-total-{companyId}";
            var cachedTotal = _context.Equipment.Where(x => x.CompanyId == companyId).Count();
            await _cache.SetAsnyc(_cacheKey, cachedTotal);
        }
    }
}
