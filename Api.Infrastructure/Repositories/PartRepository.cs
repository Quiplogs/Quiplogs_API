using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Repositories.Part;
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
    public class PartRepository : IPartRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public PartRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListPartResponse> List(string companyId, int pageNumber, int pageSize)
        {
            try
            {
                var PartList = _context.Parts.Where(x =>
                    x.CompanyId == companyId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                List<Part> mappedPart = _mapper.Map<List<Part>>(PartList);
                return new ListPartResponse(mappedPart, true, null);
            }
            catch (SqlException ex)
            {
                return new ListPartResponse(null, false, new[] { new Error(GlobalVariables.error_partFailure, $"Error fetching Part. {ex.Message}") });
            }
        }

        public async Task<GetPartResponse> Get(string id)
        {
            try
            {
                var Part = _context.Parts.FirstOrDefault(x => x.Id == id);

                Part mappedPart = _mapper.Map<Part>(Part);
                return new GetPartResponse(mappedPart, true, null);
            }
            catch (SqlException ex)
            {
                return new GetPartResponse(null, false, new[] { new Error(GlobalVariables.error_partFailure, $"Error fetching Part. {ex.Message}") });
            }
        }

        public async Task<PutPartResponse> Put(Part Part)
        {
            try
            {
                var PartMapped = _mapper.Map<PartDto>(Part);

                if (string.IsNullOrEmpty(PartMapped.Id))
                {
                    _context.Parts.Add(PartMapped);
                    await UpdateTotalItems(Part.CompanyId);
                }
                else
                {
                    _context.Parts.Update(PartMapped);
                }

                await _context.SaveChangesAsync();

                Part mappedPart = _mapper.Map<Part>(PartMapped);
                return new PutPartResponse(mappedPart, true, null);
            }
            catch (SqlException ex)
            {
                return new PutPartResponse(null, false, new[] { new Error(GlobalVariables.error_partFailure, $"Error updating Part. {ex.Message}") });
            }
        }

        public async Task<RemovePartResponse> Remove(string id)
        {
            try
            {
                var Part = _context.Parts.FirstOrDefault(x => x.Id == id);

                _context.Remove(Part);
                await _context.SaveChangesAsync();

                return new RemovePartResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemovePartResponse(null, false, new[] { new Error(GlobalVariables.error_partFailure, $"Error removing Part. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(string companyId)
        {
            var _cacheKey = $"Part-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(string companyId)
        {
            await _cache.SetAsnyc($"Part-total-{companyId}", _context.Parts.Count());
        }
    }
}
