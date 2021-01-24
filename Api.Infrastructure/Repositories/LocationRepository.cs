using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Repositories.Location;
using Api.Core.Helpers;
using Api.Core.Interfaces.Repositories;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public LocationRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListLocationResponse> List(Guid companyId, int pageNumber, string filterName, int pageSize)
        {
            try
            {
                var LocationList = _context.Locations.Where(x =>
                    x.CompanyId == companyId
                    && (filterName == null || x.Name.Contains(filterName)))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                List<Location> mappedLocation = _mapper.Map<List<Location>>(LocationList);
                return new ListLocationResponse(mappedLocation, true, null);
            }
            catch (SqlException ex)
            {
                return new ListLocationResponse(null, false, new[] { new Error("", $"Error fetching Location. {ex.Message}") });
            }
        }

        public async Task<GetLocationResponse> Get(Guid id)
        {
            try
            {
                var Location = _context.Locations.AsNoTracking().FirstOrDefault(x => x.Id == id);

                Location mappedLocation = _mapper.Map<Location>(Location);
                return new GetLocationResponse(mappedLocation, true, null);
            }
            catch (SqlException ex)
            {
                return new GetLocationResponse(null, false, new[] { new Error("", $"Error fetching Location. {ex.Message}") });
            }
        }

        public async Task RemoveImage(Guid id)
        {
            var _location = _context.Locations.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (_location != null)
            {
                _location.ImgFileName = "";
                _location.ImgUrl = "";

                _context.Locations.Update(_location);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PutLocationResponse> Put(Location location)
        {
            try
            {
                var existingLocation = _context.Locations.Find(location.Id);
                var LocationMapped = _mapper.Map<LocationDto>(location);

                if (existingLocation == null)
                {
                    _context.Locations.Add(LocationMapped);
                    await UpdateTotalItems(location.CompanyId);
                }
                else
                {
                    _context.Entry(existingLocation).CurrentValues.SetValues(LocationMapped);
                }

                await _context.SaveChangesAsync();

                Location mappedLocation = _mapper.Map<Location>(LocationMapped);
                return new PutLocationResponse(mappedLocation, true, null);
            }
            catch (SqlException ex)
            {
                return new PutLocationResponse(null, false, new[] { new Error("", $"Error updating Location. {ex.Message}") });
            }
        }

        public async Task<RemoveLocationResponse> Remove(Guid id)
        {
            try
            {
                var Location = _context.Locations.FirstOrDefault(x => x.Id == id);

                await UpdateTotalItems(Location.CompanyId);
                _context.Remove(Location);
                await _context.SaveChangesAsync();

                return new RemoveLocationResponse(id.ToString(), true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveLocationResponse(null, false, new[] { new Error("", $"Error removing Location. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(Guid companyId)
        {
            var _cacheKey = $"Location-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(Guid companyId)
        {
            await _cache.SetAsnyc($"Location-total-{companyId}", _context.Locations.Count());
        }
    }
}
