using Api.Core.Dto;
using Api.Core.Helpers;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Inventory.Data.Entities;
using Quiplogs.Inventory.Domain.Entities;
using Quiplogs.Inventory.Dto.Repositories.Part;
using Quiplogs.Inventory.Interfaces.Repositories;
using System;
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

        public async Task<ListPartResponse> List(Guid companyId, Guid locationId, string filterName, int pageNumber, int pageSize)
        {
            try
            {
                var partsList = _context.Parts.Where(x =>
                     x.CompanyId == companyId
                    && (locationId == null || x.LocationId == locationId)
                    && (filterName == null || x.Code.Contains(filterName)))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                List<Part> mappedPart = _mapper.Map<List<Part>>(partsList);
                return new ListPartResponse(mappedPart, true, null);
            }
            catch (SqlException ex)
            {
                return new ListPartResponse(null, false, new[] { new Error("", $"Error fetching Part. {ex.Message}") });
            }
        }

        public async Task<GetPartResponse> Get(Guid id)
        {
            try
            {
                var Part = _context.Parts.AsNoTracking().FirstOrDefault(x => x.Id == id);

                Part mappedPart = _mapper.Map<Part>(Part);
                return new GetPartResponse(mappedPart, true, null);
            }
            catch (SqlException ex)
            {
                return new GetPartResponse(null, false, new[] { new Error("", $"Error fetching Part. {ex.Message}") });
            }
        }

        public async Task<PutPartResponse> Put(Part model)
        {
            try
            {
                var existingModel = _context.Parts.Find(model.Id);
                var modelMapped = _mapper.Map<PartDto>(model);

                if (existingModel == null)
                {
                    _context.Parts.Add(modelMapped);
                    await UpdateTotalItems(model.CompanyId);
                }
                else
                {
                    _context.Entry(existingModel).CurrentValues.SetValues(modelMapped);
                }

                await _context.SaveChangesAsync();

                Part mappedLocation = _mapper.Map<Part>(modelMapped);
                return new PutPartResponse(mappedLocation, true, null);
            }
            catch (SqlException ex)
            {
                return new PutPartResponse(null, false, new[] { new Error("", $"Error updating Part. {ex.Message}") });
            }
        }

        public async Task RemoveImage(Guid id)
        {
            var model = _context.Parts.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                model.ImgFileName = "";
                model.ImgUrl = "";

                _context.Parts.Update(model);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<RemovePartResponse> Remove(Guid id)
        {
            try
            {
                var Part = _context.Parts.FirstOrDefault(x => x.Id == id);

                _context.Remove(Part);
                await _context.SaveChangesAsync();

                await UpdateTotalItems(Part.CompanyId);

                return new RemovePartResponse(id.ToString(), true, null);
            }
            catch (SqlException ex)
            {
                return new RemovePartResponse(null, false, new[] { new Error("", $"Error removing Part. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(Guid companyId)
        {
            var _cacheKey = $"Part-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(Guid companyId)
        {
            await _cache.SetAsnyc($"Part-total-{companyId}", _context.Parts.Count());
        }
    }
}
